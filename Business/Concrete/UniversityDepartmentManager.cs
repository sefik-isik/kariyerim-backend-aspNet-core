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
using Entities.PageModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public  class UniversityDepartmentManager : IUniversityDepartmentService
    {
        IUniversityDepartmentDal _universityDepartmentDal;
        readonly IPaginationUriService _uriService;

        public UniversityDepartmentManager(IUniversityDepartmentDal universityDepartmentDal, IPaginationUriService uriService)
        {
            _universityDepartmentDal = universityDepartmentDal;
            _uriService = uriService;

        }

        [SecuredOperation("admin")]
        public async Task<IResult> Add(UniversityDepartment universityDepartment)
        {
            IResult result = await BusinessRules.Run(IsNameExist(universityDepartment.DepartmentName));

            if (result != null)
            {
                return result;
            }
            await _universityDepartmentDal.AddAsync(universityDepartment);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(UniversityDepartment universityDepartment)
        {
            await _universityDepartmentDal.UpdateAsync(universityDepartment);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(UniversityDepartment universityDepartment)
        {
            await _universityDepartmentDal.Delete(universityDepartment);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(UniversityDepartment universityDepartment)
        {
            await _universityDepartmentDal.TerminateSubDatas(universityDepartment.Id);
            await _universityDepartmentDal.Terminate(universityDepartment);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDepartment>>> GetAll()
        {
            var result = await _universityDepartmentDal.GetAll();
            result = result.OrderBy(x => x.DepartmentName).ToList();
            return new SuccessDataResult<List<UniversityDepartment>>(result, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDepartment>>> GetDeletedAll()
        {
            var result = await _universityDepartmentDal.GetDeletedAll();
            result = result.OrderBy(x => x.DepartmentName).ToList();
            return new SuccessDataResult<List<UniversityDepartment>>(result, Messages.SuccessListed);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<UniversityDepartmentPageModel>> GetAllByPage(UniversityDepartmentPageModel pageModel)
        {
            var universityDepartments = await _universityDepartmentDal.GetAll();
            var query = universityDepartments.AsQueryable();

            if (!string.IsNullOrEmpty(pageModel.Filter))
            {
                query = query.Where(c => c.DepartmentName.ToLower().Contains(pageModel.Filter.ToLower()));
            }

            switch (pageModel.SortColumn)
            {
                case "DepartmentName":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.DepartmentName) : query.OrderBy(c => c.DepartmentName);
                    break;
                default:
                    query = query.OrderBy(c => c.DepartmentName);
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

            var universityDepartmentPageModel = new UniversityDepartmentPageModel
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

            return new SuccessDataResult<UniversityDepartmentPageModel>(universityDepartmentPageModel, Messages.SuccessListed);
        }

        
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<UniversityDepartment?>> GetById(string id)
        {
            return new SuccessDataResult<UniversityDepartment?>(await _universityDepartmentDal.Get(f => f.Id == id));
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _universityDepartmentDal.GetAll(c => c.DepartmentName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
