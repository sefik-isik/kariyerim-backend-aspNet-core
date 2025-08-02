using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
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
    public class PositionManager : IPositionService
    {
        IPositionDal _positionDal;
        readonly IPaginationUriService _uriService;

        public PositionManager(IPositionDal positionDal, IPaginationUriService uriService)
        {
            _positionDal = positionDal;
            _uriService = uriService;
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Add(Position position)
        {
            IResult result = await BusinessRules.Run(IsNameExist(position.PositionName));

            if (result != null)
            {
                return result;
            }
            await _positionDal.AddAsync(position);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(Position position)
        {
            await _positionDal.UpdateAsync(position);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(Position position)
        {
            await _positionDal.Delete(position);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(Position position)
        {
            await _positionDal.Terminate(position);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Position>>> GetAll()
        {
            var result = await _positionDal.GetAll();
            result = result.OrderBy(x => x.PositionName).ToList();
            return new SuccessDataResult<List<Position>>(result, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Position>>> GetDeletedAll()
        {
            var result = await _positionDal.GetDeletedAll();
            result = result.OrderBy(x => x.PositionName).ToList();
            return new SuccessDataResult<List<Position>>(result, Messages.SuccessListed);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<PositionPageModel>> GetAllByPage(PositionPageModel pageModel)
        {
            var datas = await _positionDal.GetAll();
            var query = datas.AsQueryable();

            switch (pageModel.SortColumn)
            {
                case "PositionName":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.PositionName) : query.OrderBy(c => c.PositionName);
                    break;
                default:
                    query = query.OrderBy(c => c.PositionName);
                    break;
            }

            var onePageContactQuery = query.Skip(pageModel.PageSize * pageModel.PageIndex).Take(pageModel.PageSize).ToList();
            var pageContactResult = onePageContactQuery.ToList();
            var totalCount = query.Count();
            var totalPages = Convert.ToInt32(Math.Ceiling((double)totalCount / pageModel.PageSize));

            Uri? nextPage = pageModel.PageIndex +1 >= 1 && pageModel.PageIndex < totalPages
                ? _uriService.GetPageUri(new PageModel { PageIndex = pageModel.PageIndex + 1, PageSize = pageModel.PageSize })
                : null;
            Uri? previousPage = pageModel.PageIndex - 1 >= 1 && pageModel.PageIndex <= totalPages
                ? _uriService.GetPageUri(new PageModel { PageIndex = pageModel.PageIndex - 1, PageSize = pageModel.PageSize })
                : null;
            Uri? firstPage = _uriService.GetPageUri(new PageModel { PageIndex = 1, PageSize = pageModel.PageSize });
            Uri? lastPage = _uriService.GetPageUri(new PageModel { PageIndex = totalPages, PageSize = pageModel.PageSize });
            Uri? currentPage = _uriService.GetPageUri(pageModel);

            var positionPageModel = new PositionPageModel
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
                CurrentPage= currentPage
            };

            return new SuccessDataResult<PositionPageModel>(positionPageModel, Messages.SuccessListed);
        }

        
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<Position?>> GetById(string id)
        {
            return new SuccessDataResult<Position?>(await _positionDal.Get(l => l.Id == id));
        }
        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _positionDal.GetAll(c => c.PositionName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}