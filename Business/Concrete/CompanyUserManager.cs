using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Entities.PageModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyUserManager : ICompanyUserService
    {
        ICompanyUserDal _companyUserDal;
        IUserService _userService;
        ICompanyUserImageService _companyUserImageService;
        readonly IPaginationUriService _uriService;

        public CompanyUserManager(
            ICompanyUserDal companyUserDal, 
            IUserService userService, IPaginationUriService paginationUriService, ICompanyUserImageService companyUserImageService
            ) {
            _companyUserDal = companyUserDal; 
            _userService = userService;
            _uriService = paginationUriService;
            _companyUserImageService = companyUserImageService;
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CompanyUserValidator))]
        [CacheRemoveAspect()]
        public async Task<IResult> Add(CompanyUser companyUser)
        {
            IResult result = await  BusinessRules.Run(
                IsCompanyNameExist(companyUser.CompanyUserName),
                await IsTaxNumberExist(companyUser.TaxNumber), 
                await IsWebAddressExist(companyUser.WebAddress));
            if (result != null)
            {
                return result;
            }
            if (_userService.GetById(companyUser.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserDal.AddAsync(companyUser);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CompanyUserValidator))]
        [CacheRemoveAspect()]
        public async Task<IResult> Update(CompanyUser companyUser)
        {
            if (_userService.GetById(companyUser.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserDal.UpdateAsync(companyUser);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        [CacheRemoveAspect()]
        public async Task<IResult> Delete(CompanyUser companyUser)
        {
            if (_userService.GetById(companyUser.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserDal.Delete(companyUser);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(CompanyUser companyUser)
        {
            List<CompanyUserImage>? companyUserImages = await _companyUserImageService.GetAllByCompanyUserId(companyUser.Id);

            if(companyUserImages.Count>0)
            {
                foreach (CompanyUserImage image in companyUserImages)
                {
                    await _companyUserImageService.DeleteImage(image);
                }
            }

            await _companyUserDal.TerminateSubDatas(companyUser.Id);
            await _companyUserDal.Terminate(companyUser);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUser>>> GetAll(UserAdminDTO userAdminDTO) 
        
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUser>>(await _companyUserDal.GetAll(c => c.UserId == userAdminDTO.Id), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUser>>(await _companyUserDal.GetAll(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUser>>> GetDeletedAll(UserAdminDTO userAdminDTO)

        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUser>>(await _companyUserDal.GetDeletedAll(c => c.UserId == userAdminDTO.Id), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUser>>(await _companyUserDal.GetDeletedAll(), Messages.SuccessListed);
            }
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUserPageModel>> GetAllByPage(CompanyUserPageModel pageModel)
        {
            var datas = await _companyUserDal.GetAllDTO();
            var query = datas.AsQueryable();

            if (!string.IsNullOrEmpty(pageModel.Filter))
            {
                query = query.Where(c => c.CompanyUserName.ToLower().Contains(pageModel.Filter.ToLower()) ||
                                         c.Email.ToLower().Contains(pageModel.Filter.ToLower()) ||
                                         c.TaxNumber.ToLower().Contains(pageModel.Filter.ToLower()));
            }

            switch (pageModel.SortColumn)
            {
                case "Email":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.Email) : query.OrderBy(c => c.Email);
                    break;
                case "CompanyUserName":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.CompanyUserName) : query.OrderBy(c => c.CompanyUserName);
                    break;
                default:
                    query = query.OrderBy(c => c.CompanyUserName);
                    break;
            }

            var onePageContactQuery = query.Skip(pageModel.PageSize * pageModel.PageIndex).Take(pageModel.PageSize).ToList();
            var pageContactResult = onePageContactQuery.ToList();
            var totalCount = query.Count();
            var totalPages = Convert.ToInt32(Math.Ceiling((double)totalCount / pageModel.PageSize));

            Uri? nextPage = pageModel.PageIndex + 1 >= 1 && pageModel.PageIndex < totalPages
                ? _uriService.GetPageUri(new PageModel { PageIndex = pageModel.PageIndex + 1, PageSize = pageModel.PageSize })
                : null;
            Uri? previousPage = pageModel.PageIndex - 1 >= 1 && pageModel.PageIndex <= totalPages
                ? _uriService.GetPageUri(new PageModel { PageIndex = pageModel.PageIndex - 1, PageSize = pageModel.PageSize })
                : null;
            Uri? firstPage = _uriService.GetPageUri(new PageModel { PageIndex = 1, PageSize = pageModel.PageSize });
            Uri? lastPage = _uriService.GetPageUri(new PageModel { PageIndex = totalPages, PageSize = pageModel.PageSize });
            Uri? currentPage = _uriService.GetPageUri(pageModel);

            var companyUserPageModel = new CompanyUserPageModel
            {
                PageContacts = pageContactResult,
                ContactTotalCount = totalCount,
                PageIndex = pageModel.PageIndex,
                PageSize = pageModel.PageSize,
                SortColumn = pageModel.SortColumn ?? string.Empty,
                SortOrder = pageModel.SortOrder ?? string.Empty,
                NextPage = nextPage,
                PreviousPage = previousPage,
                FirstPage = firstPage,
                LastPage = lastPage,
                TotalPages = totalPages,
                CurrentPage = currentPage
            };

            return new SuccessDataResult<CompanyUserPageModel>(companyUserPageModel, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUser?>> GetByAdminId(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUser?>(await _companyUserDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<CompanyUser?>(await _companyUserDal.Get(c => c.Id == userAdminDTO.Id), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUser?>> GetById(string id)
        {
            return new SuccessDataResult<CompanyUser?>(await _companyUserDal.Get(c => c.Id == id));

        }

        //DTO
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var user = await _userService.GetById(userAdminDTO.UserId);
            var alldto = await _companyUserDal.GetAllDTO();

            if (userIsAdmin.Data == null && user.Code == UserCode.CompanyUser)
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((alldto.OrderBy(x => x.CompanyUserName).ToList().FindAll(c => c.UserId == userAdminDTO.Id)), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDTO>>(alldto.OrderBy(x => x.CompanyUserName).ToList(), Messages.SuccessListed);
            }
            
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var user = await _userService.GetById(userAdminDTO.UserId);
            var alldto = await _companyUserDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null && user.Code == UserCode.CompanyUser)
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((alldto.OrderBy(x => x.CompanyUserName).ToList().FindAll(c => c.UserId == userAdminDTO.Id)), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDTO>>(alldto.OrderBy(x => x.CompanyUserName).ToList(), Messages.SuccessListed);
            }
        } 

        //Business Rules
        private async Task<IResult> IsCompanyNameExist(string companyName)
        {
            var result =await _companyUserDal.GetAll(c => c.CompanyUserName.ToLower() == companyName.ToLower() && c.CompanyUserName  != "-");

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

        private async Task<IResult> IsTaxNumberExist(string taxNumber)
        {
            var result =await _companyUserDal.GetAll(c => c.TaxNumber.ToLower() == taxNumber.ToLower() && c.TaxNumber != "-");

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

        private async Task<IResult> IsWebAddressExist(string webAddress)
        {
            var result =await _companyUserDal.GetAll(c => c.WebAddress.ToLower() == webAddress.ToLower() && c.WebAddress != "-");

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }


    }
}