using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Entities.PageModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyUserAdvertManager : ICompanyUserAdvertService
    {
        ICompanyUserAdvertDal _companyUserAdvertDal;
        IUserService _userService;
        readonly IWebHostEnvironment _environment;
        readonly IPaginationUriService _uriService;

        public CompanyUserAdvertManager(ICompanyUserAdvertDal companyUserAdvertDal,
            IUserService userService, IWebHostEnvironment environment,
            IPaginationUriService paginationUriService)
        {
            _companyUserAdvertDal = companyUserAdvertDal;
            _userService = userService;
            _environment = environment;
            _uriService = paginationUriService;
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(CompanyUserAdvert companyUserAdvert)
        {
            if (_userService.GetById(companyUserAdvert.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            IResult result = await BusinessRules.Run(IsNameExist(companyUserAdvert.AdvertName));

            if (result != null)
            {
                return result;
            }
            await _companyUserAdvertDal.AddAsync(companyUserAdvert);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(CompanyUserAdvert companyUserAdvert)
        {
            if (_userService.GetById(companyUserAdvert.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserAdvertDal.UpdateAsync(companyUserAdvert);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(CompanyUserAdvert companyUserAdvert)
        {
            if (_userService.GetById(companyUserAdvert.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserAdvertDal.Delete(companyUserAdvert);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Terminate(CompanyUserAdvert companyUserAdvert)
        {
            await _companyUserAdvertDal.TerminateSubDatas(companyUserAdvert.Id);
            await _companyUserAdvertDal.Terminate(companyUserAdvert);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvert>>> GetAll()
        {

            return new SuccessDataResult<List<CompanyUserAdvert>>(await _companyUserAdvertDal.GetAll(), Messages.SuccessListed);
        }

        public async Task<List<CompanyUserAdvert>> GetAllByCompanyUserId(CompanyUser companyUser)
        {

            return await _companyUserAdvertDal.GetAll(c => c.CompanyUserId == companyUser.Id);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvert>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvert>>(await _companyUserAdvertDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvert>>(await _companyUserAdvertDal.GetDeletedAll(), Messages.SuccessListed);
            }
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUserAdvert?>> GetById(string id)
        {

            return new SuccessDataResult<CompanyUserAdvert?>(await _companyUserAdvertDal.Get(c => c.Id == id));
        }


        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUserAdvertPageModel>> GetAllByPage(CompanyUserAdvertPageModel companyUserAdvertPageModel)
        {
            companyUserAdvertPageModel.PageContacts = await _companyUserAdvertDal.GetAllDTO();
            var query = companyUserAdvertPageModel.PageContacts.AsQueryable();

            if (companyUserAdvertPageModel.PageContacts.Count>0 && companyUserAdvertPageModel.Filters?.Count>0)
            {
                foreach (var advertFilter in companyUserAdvertPageModel.Filters)
                {
                    switch (advertFilter.FilterName)
                    {
                        case "AdvertName":
                            query = query.Where(c => c.AdvertName.Contains(advertFilter.FilterValue));
                            break;
                        case "CompanyUserName":
                            query = query.Where(c => c.CompanyUserName == advertFilter.FilterValue);
                            break;
                        case "CityName":
                            query = query.Where(c => c.CityName.Contains(advertFilter.FilterValue));
                            break;
                        case "RegionName":
                            query = query.Where(c => c.RegionName.Contains(advertFilter.FilterValue));
                            break;
                        case "AreaName":
                            query = query.Where(c => c.WorkAreaName.Contains(advertFilter.FilterValue));
                            break;
                        case "CreateDate":
                            var filterDate = DateTime.Parse(advertFilter.FilterValue);
                            query = query.Where(c => c.CreatedDate.Day == filterDate.Day || c.CreatedDate >= filterDate);
                            break;
                        case "SectorName":
                            query = query.Where(c => c.SectorName.Contains(advertFilter.FilterValue));
                            break;
                        case "PositionLevelName":
                            query = query.Where(c => c.PositionLevelName.Contains(advertFilter.FilterValue));
                            break;
                        case "DepartmentName":
                            query = query.Where(c => c.DepartmentName.Contains(advertFilter.FilterValue));
                            break;
                        case "MethodName":
                            query = query.Where(c => c.WorkingMethodName.Contains(advertFilter.FilterValue));
                            break;
                        case "LicenseDegreeName":
                            query = query.Where(c => c.LicenseDegreeName.Contains(advertFilter.FilterValue));
                            break;
                        case "PositionName":
                            query = query.Where(c => c.PositionName.Contains(advertFilter.FilterValue));
                            break;
                        case "ExperienceName":
                            query = query.Where(c => c.ExperienceName.Contains(advertFilter.FilterValue));
                            break;
                        default:
                            query = query.OrderBy(c => c.CreatedDate);
                            break;
                    }
                }
            }

            switch (companyUserAdvertPageModel.SortColumn)
            {
                case "AdvertName":
                    query = companyUserAdvertPageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.AdvertName) : query.OrderBy(c => c.AdvertName);
                    break;
                default:
                    query = query.OrderBy(c => c.CreatedDate);
                    break;
            }

            var onePageContactQuery = query.Skip(companyUserAdvertPageModel.PageSize * companyUserAdvertPageModel.PageIndex).Take(companyUserAdvertPageModel.PageSize).ToList();
            var pageContactResult = onePageContactQuery.ToList();
            var totalCount = query.Count();
            var totalPages = Convert.ToInt32(Math.Ceiling((double)totalCount / companyUserAdvertPageModel.PageSize));

            Uri? nextPage = companyUserAdvertPageModel.PageIndex + 1 >= 1 && companyUserAdvertPageModel.PageIndex < totalPages
                ? _uriService.GetPageUri(new PageModel { PageIndex = companyUserAdvertPageModel.PageIndex + 1, PageSize = companyUserAdvertPageModel.PageSize })
                : null;
            Uri? previousPage = companyUserAdvertPageModel.PageIndex - 1 >= 1 && companyUserAdvertPageModel.PageIndex <= totalPages
                ? _uriService.GetPageUri(new PageModel { PageIndex = companyUserAdvertPageModel.PageIndex - 1, PageSize = companyUserAdvertPageModel.PageSize })
                : null;
            Uri? firstPage = _uriService.GetPageUri(new PageModel { PageIndex = 1, PageSize = companyUserAdvertPageModel.PageSize });
            Uri? lastPage = _uriService.GetPageUri(new PageModel { PageIndex = totalPages, PageSize = companyUserAdvertPageModel.PageSize });
            Uri? currentPage = _uriService.GetPageUri(companyUserAdvertPageModel);

            var companyUserAdvertPageModelFinal = new CompanyUserAdvertPageModel
            {
                PageContacts = pageContactResult,
                ContactTotalCount = totalCount,
                PageIndex = companyUserAdvertPageModel.PageIndex,
                PageSize = companyUserAdvertPageModel.PageSize,
                SortColumn = companyUserAdvertPageModel.SortColumn ?? string.Empty,
                SortOrder = companyUserAdvertPageModel.SortOrder ?? string.Empty,
                NextPage = nextPage,
                PreviousPage = previousPage,
                FirstPage = firstPage,
                LastPage = lastPage,
                TotalPages = totalPages,
                CurrentPage = currentPage
            };

            return new SuccessDataResult<CompanyUserAdvertPageModel>(companyUserAdvertPageModelFinal, Messages.SuccessListed);
        }

        //DTO
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertDTO>>> GetAllDTO()
        {
            var allDtos = await _companyUserAdvertDal.GetAllDTO();

            return new SuccessDataResult<List<CompanyUserAdvertDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var user = await _userService.GetById(userAdminDTO.UserId);
            var allDtos = await _companyUserAdvertDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null && user.Code == UserCode.CompanyUser)
            {
                return new SuccessDataResult<List<CompanyUserAdvertDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _companyUserAdvertDal.GetAll(c => c.AdvertName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
