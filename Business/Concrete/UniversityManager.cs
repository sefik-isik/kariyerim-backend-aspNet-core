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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UniversityManager: IUniversityService
    {
        IUniversityDal _universityDal;
        readonly IPaginationUriService _uriService;

        public UniversityManager(IUniversityDal universityDal, IPaginationUriService uriService)
        {
            _universityDal = universityDal;
            _uriService = uriService;

        }

        [SecuredOperation("admin")]
        public async Task<IResult> Add(University university)
        {
            IResult result = await BusinessRules.Run(
                IsNameExist(university.UniversityName),
              await IsWebAddressExist(university.WebAddress),
              await IsWebNewsAddressExist(university.WebNewsAddress),
              await IsYouTubeEmbedAddressExist(university.YouTubeEmbedAddress),
              await IsAddressExist(university.Address),
              await IsFacebookAddressExist(university.FacebookAddress),
              await IsInstagramAddressExist(university.InstagramAddress),
              await IsXAddressExist(university.XAddress),
              await IsYouTubeAddressExist(university.YouTubeAddress)
                );

            if (result != null)
            {
                return result;
            }
            await _universityDal.AddAsync(university);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(University university)
        {
            await _universityDal.UpdateAsync(university);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(University university)
        {
            await _universityDal.Delete(university);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(University university)
        {
            await _universityDal.TerminateSubDatas(university.Id);
            await _universityDal.Terminate(university);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<University>>> GetAll()
        {
            var result = await _universityDal.GetAll();
            result = result.OrderBy(x => x.UniversityName).ToList();
            return new SuccessDataResult<List<University>>(result, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<University>>> GetDeletedAll()
        {
            var result = await _universityDal.GetDeletedAll();
            result = result.OrderBy(x => x.UniversityName).ToList();
            return new SuccessDataResult<List<University>>(result, Messages.SuccessListed);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<UniversityPageModel>> GetAllByPage(UniversityPageModel pageModel)
        {
            var datas = await _universityDal.GetAllDTO();
            var query = datas.AsQueryable();

            if (!string.IsNullOrEmpty(pageModel.Filter))
            {
                query = query.Where(c => c.UniversityName.ToLower().Contains(pageModel.Filter.ToLower()));
            }

            switch (pageModel.SortColumn)
            {
                case "UniversityName":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.UniversityName) : query.OrderBy(c => c.UniversityName);
                    break;
                default:
                    query = query.OrderBy(c => c.UniversityName);
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

            var universityPageModel = new UniversityPageModel
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

            return new SuccessDataResult<UniversityPageModel>(universityPageModel, Messages.SuccessListed);
        }

        
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<University?>> GetById(string id)
        {
            return new SuccessDataResult<University?>(await _universityDal.Get(u=>u.Id == id));
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDTO>>> GetAllDTO()
        {
            var result = await _universityDal.GetAllDTO();
            result = result.OrderBy(x => x.UniversityName).ToList();
            return new SuccessDataResult<List<UniversityDTO>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDTO>>> GetDeletedAllDTO()
        {
            var result = await _universityDal.GetDeletedAllDTO();
            result = result.OrderBy(x => x.UniversityName).ToList();
            return new SuccessDataResult<List<UniversityDTO>>(result, Messages.SuccessListed);
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _universityDal.GetAll(c => c.UniversityName.ToLower() == entityName.ToLower());

           if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsWebAddressExist(string entityName)
        {
            var result = await _universityDal.GetAll(c => c.WebAddress.ToLower() == entityName.ToLower() && c.WebAddress != "-");

           if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsWebNewsAddressExist(string entityName)
        {
            var result = await _universityDal.GetAll(c => c.WebNewsAddress.ToLower() == entityName.ToLower() && c.WebNewsAddress != "-");

           if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsYouTubeEmbedAddressExist(string entityName)
        {
            var result = await _universityDal.GetAll(c => c.YouTubeEmbedAddress.ToLower() == entityName.ToLower() && c.YouTubeEmbedAddress != "-");

           if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsAddressExist(string entityName)
        {
            var result = await _universityDal.GetAll(c => c.Address.ToLower() == entityName.ToLower() && c.Address != "-");

           if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsFacebookAddressExist(string entityName)
        {
            var result = await _universityDal.GetAll(c => c.FacebookAddress.ToLower() == entityName.ToLower() && c.FacebookAddress != "-");

           if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsInstagramAddressExist(string entityName)
        {
            var result = await _universityDal.GetAll(c => c.InstagramAddress.ToLower() == entityName.ToLower() && c.InstagramAddress != "-");

           if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsXAddressExist(string entityName)
        {
            var result = await _universityDal.GetAll(c => c.XAddress.ToLower() == entityName.ToLower() && c.XAddress != "-");

           if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsYouTubeAddressExist(string entityName)
        {
            var result = await _universityDal.GetAll(c => c.YouTubeAddress.ToLower() == entityName.ToLower() && c.YouTubeAddress != "-");

           if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
