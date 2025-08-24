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
            await DeleteImage(companyUserAdvert);
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

            return await _companyUserAdvertDal.GetAll(c=>c.CompanyUserId == companyUser.Id);
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

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUserAdvert?>> GetById(string id)
        {

            return new SuccessDataResult<CompanyUserAdvert?>(await _companyUserAdvertDal.Get(c => c.Id == id));
        }


        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUserAdvertPageModel>> GetAllByPage(CompanyUserAdvertPageModel pageListModel)
        {
            var datas = await _companyUserAdvertDal.GetAllDTO();
            var query = datas.AsQueryable();

            if (pageListModel.Filters?.Count > 0)
            {
                foreach (var advertFilter in pageListModel.Filters)
                {
                    switch (advertFilter.FilterName)
                    {
                        case "AdvertName":
                            query = query.Where(c => c.AdvertName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        case "CompanyUserName":
                            query = query.Where(c => c.CompanyUserName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        case "CityName":
                            query = query.Where(c => c.CityName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        case "RegionName":
                            query = query.Where(c => c.RegionName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        case "AreaName":
                            query = query.Where(c => c.WorkAreaName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        case "CreateDate":
                            query = query.Where(c => c.CreatedDate.ToLongDateString().Contains(advertFilter.FilterValue));
                            break;
                        case "SectorName":
                            query = query.Where(c => c.SectorName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        case "PositionLevelName":
                            query = query.Where(c => c.PositionLevelName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        case "DepartmentName":
                            query = query.Where(c => c.DepartmentName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        case "MethodName":
                            query = query.Where(c => c.WorkingMethodName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        case "LicenseDegreeName":
                            query = query.Where(c => c.LicenseDegreeName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        case "PositionName":
                            query = query.Where(c => c.PositionName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        case "ExperienceName":
                            query = query.Where(c => c.ExperienceName.ToLower().Contains(advertFilter.FilterValue.ToLower()));
                            break;
                        default:
                            query = query.OrderBy(c => c.CreatedDate);
                            break;
                    }
                }
            }

            switch (pageListModel.SortColumn)
            {
                case "AdvertName":
                    query = pageListModel.SortOrder == "desc" ? query.OrderByDescending(c => c.AdvertName) : query.OrderBy(c => c.AdvertName);
                    break;
                default:
                    query = query.OrderBy(c => c.CreatedDate);
                    break;
            }

            var onePageContactQuery = query.Skip(pageListModel.PageSize * pageListModel.PageIndex).Take(pageListModel.PageSize).ToList();
            var pageContactResult = onePageContactQuery.ToList();
            var totalCount = query.Count();
            var totalPages = Convert.ToInt32(Math.Ceiling((double)totalCount / pageListModel.PageSize));

            Uri? nextPage = pageListModel.PageIndex + 1 >= 1 && pageListModel.PageIndex < totalPages
                ? _uriService.GetPageUri(new PageModel { PageIndex = pageListModel.PageIndex + 1, PageSize = pageListModel.PageSize })
                : null;
            Uri? previousPage = pageListModel.PageIndex - 1 >= 1 && pageListModel.PageIndex <= totalPages
                ? _uriService.GetPageUri(new PageModel { PageIndex = pageListModel.PageIndex - 1, PageSize = pageListModel.PageSize })
                : null;
            Uri? firstPage = _uriService.GetPageUri(new PageModel { PageIndex = 1, PageSize = pageListModel.PageSize });
            Uri? lastPage = _uriService.GetPageUri(new PageModel { PageIndex = totalPages, PageSize = pageListModel.PageSize });
            Uri? currentPage = _uriService.GetPageListUri(pageListModel);

            var companyUserAdvertPageModel = new CompanyUserAdvertPageModel
            {
                PageContacts = pageContactResult,
                ContactTotalCount = totalCount,
                PageIndex = pageListModel.PageIndex,
                PageSize = pageListModel.PageSize,
                SortColumn = pageListModel.SortColumn ?? string.Empty,
                SortOrder = pageListModel.SortOrder ?? string.Empty,
                NextPage = nextPage,
                PreviousPage = previousPage,
                FirstPage = firstPage,
                LastPage = lastPage,
                TotalPages = totalPages,
                CurrentPage = currentPage
            };

            return new SuccessDataResult<CompanyUserAdvertPageModel>(companyUserAdvertPageModel, Messages.SuccessListed);
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

        public async Task<IResult> DeleteImage(CompanyUserAdvert companyUserAdvert)
        {
            if (companyUserAdvert == null)
            {
                return new ErrorDataResult<CompanyUserAdvert>(Messages.ImageNotFound);
            }

            string ImagePath = _environment.WebRootPath + "\\uploads\\images\\" + companyUserAdvert.UserId;
            string FullImagePath = ImagePath + "\\" + companyUserAdvert.AdvertImageName;

            string ThumbImagePath = ImagePath + "\\thumbs\\";
            string FullThumbImagePath = ThumbImagePath + companyUserAdvert.AdvertImageName;

            if (System.IO.File.Exists(FullImagePath))
            {
                System.IO.File.Delete(FullImagePath);
            }

            if (System.IO.File.Exists(FullThumbImagePath))
            {
                System.IO.File.Delete(FullThumbImagePath);
            }

            DirectoryInfo source = new DirectoryInfo(ImagePath);
            FileInfo[] sourceFiles = source.GetFiles();

            if(sourceFiles.Length==0)
            {
                System.IO.Directory.Delete(ImagePath,true);
            }

            companyUserAdvert.AdvertImagePath = "https://localhost:7088/" + "/uploads/images/common/";
            companyUserAdvert.AdvertImageName = "noImage.jpg";

            await Update(companyUserAdvert);

            return new SuccessResult();
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
