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
using Entities.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SectorManager : ISectorService
    {
        ISectorDal _sectorDal;
        readonly IPaginationUriService _uriService;

        public SectorManager(ISectorDal sectorDal, IPaginationUriService uriService)
        {
            _sectorDal = sectorDal;
            _uriService = uriService;

        }
        [SecuredOperation("admin")]
        public async Task<IResult> Add(Sector sector)
        {
            IResult result = await BusinessRules.Run(IsNameExist(sector.SectorName));

            if (result != null)
            {
                return result;
            }
            await _sectorDal.AddAsync(sector);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(Sector sector)
        {
            await _sectorDal.UpdateAsync(sector);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(Sector sector)
        {
            await _sectorDal.Delete(sector);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(Sector sector)
        {
            await _sectorDal.Terminate(sector);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Sector>>> GetAll()
        {
            var result = await _sectorDal.GetAll();
            result = result.OrderBy(x => x.SectorName).ToList();
            return new SuccessDataResult<List<Sector>>(result, Messages.SuccessListed);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<SectorPageModel>> GetAllByPage(SectorPageModel pageModel)
        {
            var datas = await _sectorDal.GetAll();
            var query = datas.AsQueryable();

            if (!string.IsNullOrEmpty(pageModel.Filter))
            {
                query = query.Where(c => c.SectorName.ToLower().Contains(pageModel.Filter.ToLower()));
            }

            switch (pageModel.SortColumn)
            {
                case "SectorName":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.SectorName) : query.OrderBy(c => c.SectorName);
                    break;
                default:
                    query = query.OrderBy(c => c.SectorName);
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

            var sectorPageModel = new SectorPageModel
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

            return new SuccessDataResult<SectorPageModel>(sectorPageModel, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Sector>>> GetDeletedAll()
        {
            var result = await _sectorDal.GetDeletedAll();
            result = result.OrderBy(x => x.SectorName).ToList();
            return new SuccessDataResult<List<Sector>>(result, Messages.SuccessListed);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<Sector?>> GetById(string id)
        {
            return new SuccessDataResult<Sector?>(await _sectorDal.Get(c=> c.Id == id));
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _sectorDal.GetAll(c => c.SectorName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
