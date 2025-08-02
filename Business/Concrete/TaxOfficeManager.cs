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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TaxOfficeManager: ITaxOfficeService
    {
        ITaxOfficeDal _taxOfficeDal;
        readonly IPaginationUriService _uriService;

        public TaxOfficeManager(ITaxOfficeDal taxOfficeDal, IPaginationUriService uriService)
        {
            _taxOfficeDal = taxOfficeDal;
            _uriService = uriService;

        }
        [SecuredOperation("admin")]
        public async Task<IResult> Add(TaxOffice taxOffice)
        {
            IResult result = await BusinessRules.Run(IsNameExist(taxOffice.TaxOfficeName), await IsCodeExist(taxOffice.TaxOfficeName));

            if (result != null)
            {
                return result;
            }
            await _taxOfficeDal.AddAsync(taxOffice);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(TaxOffice taxOffice)
        {
            await _taxOfficeDal.UpdateAsync(taxOffice);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(TaxOffice taxOffice)
        {
            await _taxOfficeDal.Delete(taxOffice);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(TaxOffice taxOffice)
        {
            await _taxOfficeDal.Terminate(taxOffice);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<TaxOffice>>> GetAll()
        {
            var result = await _taxOfficeDal.GetAll();
            result = result.OrderBy(x => x.TaxOfficeName).ToList();
            return new SuccessDataResult<List<TaxOffice>>(result);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<TaxOffice>>> GetDeletedAll()
        {
            var result = await _taxOfficeDal.GetDeletedAll();
            result = result.OrderBy(x => x.TaxOfficeName).ToList();
            return new SuccessDataResult<List<TaxOffice>>(result);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<TaxOfficePageModel>> GetAllByPage(TaxOfficePageModel pageModel)
        {
            var datas = await _taxOfficeDal.GetAll();
            var query = datas.AsQueryable();

            if (!string.IsNullOrEmpty(pageModel.Filter))
            {
                query = query.Where(c => c.TaxOfficeName.ToLower().Contains(pageModel.Filter.ToLower())
                                         || c.TaxOfficeCode.ToLower().Contains(pageModel.Filter.ToLower()));
            }

            switch (pageModel.SortColumn)
            {
                case "TaxOfficeName":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.TaxOfficeName) : query.OrderBy(c => c.TaxOfficeName);
                    break;
                default:
                    query = query.OrderBy(c => c.TaxOfficeName);
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

            var universityPageModel = new TaxOfficePageModel
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

            return new SuccessDataResult<TaxOfficePageModel>(universityPageModel, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<TaxOffice>> GetById(string id)
        {
            return new SuccessDataResult<TaxOffice>(await _taxOfficeDal.Get(t=>t.Id == id));
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<TaxOfficeDTO>>> GetAllDTO()
        {
            var result = await _taxOfficeDal.GetAllDTO();
            result = result.OrderBy(x => x.TaxOfficeName).ToList();
            return new SuccessDataResult<List<TaxOfficeDTO>>(result, Messages.SuccessListed);
        }
        public async Task<IDataResult<List<TaxOfficeDTO>>> GetDeletedAllDTO()
        {
            var result = await _taxOfficeDal.GetDeletedAllDTO();
            result = result.OrderBy(x => x.TaxOfficeName).ToList();
            return new SuccessDataResult<List<TaxOfficeDTO>>(result, Messages.SuccessListed);
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _taxOfficeDal.GetAll(c => c.TaxOfficeName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

        private async Task<IResult> IsCodeExist(string entityName)
        {
            var result = await _taxOfficeDal.GetAll(c => c.TaxOfficeCode.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
