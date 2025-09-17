using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
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
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelUserManager : IPersonelUserService
    {
        IPersonelUserDal _personelUserDal;
        IUserService _userService;
        IPersonelUserImageService _personelUserImageService;
        readonly IPaginationUriService _uriService;

        public PersonelUserManager(IPersonelUserDal personelUserDal, 
            IUserService userService,
            IPaginationUriService uriService, IPersonelUserImageService personelUserImageService)
        {
            _personelUserDal = personelUserDal;
            _userService = userService;
            _uriService = uriService;
            _personelUserImageService = personelUserImageService;

        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(PersonelUser personelUser)
        {
            if (_userService.GetById(personelUser.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            IResult result = await BusinessRules.Run(IsPersonelUserExist(personelUser.UserId), await IsNameExist(personelUser.IdentityNumber));

            if (result != null)
            {
                return result;
            }
            await _personelUserDal.AddAsync(personelUser);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(PersonelUser personelUser)
        {
            if (_userService.GetById(personelUser.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserDal.UpdateAsync(personelUser);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(PersonelUser personelUser)
        {
            if (_userService.GetById(personelUser.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }

            await _personelUserDal.Delete(personelUser);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(PersonelUser personelUser)
        {
            List<PersonelUserImage>? personelUserImages = await _personelUserImageService.GetAllByPersonelUserId(personelUser.Id);

            if (personelUserImages.Count > 0)
            {
                foreach (PersonelUserImage image in personelUserImages)
                {
                    await _personelUserImageService.DeleteImage(image);
                }
            }

            await _personelUserDal.TerminateSubDatas(personelUser.Id);
            await _personelUserDal.Terminate(personelUser);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUser>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUser>>(await _personelUserDal.GetAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUser>>(await _personelUserDal.GetAll(), Messages.SuccessListed);
            }

        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUser>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUser>>(await _personelUserDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUser>>(await _personelUserDal.GetDeletedAll(), Messages.SuccessListed);
            }
        }


        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserPageModel>> GetAllByPage(PersonelUserPageModel pageModel)
        {
            var datas = await _personelUserDal.GetAllDTO();
            var query = datas.AsQueryable();

            if (!string.IsNullOrEmpty(pageModel.Filter))
            {
                query = query.Where(c => c.FirstName.ToLower().Contains(pageModel.Filter.ToLower())
                                         || c.LastName.ToLower().Contains(pageModel.Filter.ToLower())
                                         || c.Email.ToLower().Contains(pageModel.Filter.ToLower())
                                         || c.IdentityNumber.Contains(pageModel.Filter));
            }

            switch (pageModel.SortColumn)
            {
                case "FirstName":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.FirstName) : query.OrderBy(c => c.FirstName);
                    break;
                case "LastName":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.LastName) : query.OrderBy(c => c.LastName);
                    break;
                case "Email":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.Email) : query.OrderBy(c => c.Email);
                    break;

                default:
                    query = query.OrderBy(c => c.IdentityNumber);
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

            var positionPageModel = new PersonelUserPageModel
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

            return new SuccessDataResult<PersonelUserPageModel>(positionPageModel, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUser?>> GetByUserId(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUser?>(await _personelUserDal.Get(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<PersonelUser?>(await _personelUserDal.Get(c => c.Id == userAdminDTO.Id), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUser?>> GetById(string id)
        {
            return new SuccessDataResult<PersonelUser?>(await _personelUserDal.Get(c => c.Id == id));

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserDTO>>> GetByIdDTO(string id)
        {
            var allDtos = await _personelUserDal.GetByIdDTO(id);

            return new SuccessDataResult<List<PersonelUserDTO>>(allDtos.ToList());

        }

        //DTO
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var allDtos = await _personelUserDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var allDtos = await _personelUserDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        //Business Rules
        private async Task<IResult> IsPersonelUserExist(string id)
        {
            var result = await _personelUserDal.GetAll(c => c.UserId == id);

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _personelUserDal.GetAll(c => c.IdentityNumber == entityName && c.IdentityNumber != "-");

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
