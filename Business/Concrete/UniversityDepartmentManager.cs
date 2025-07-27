using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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

        public UniversityDepartmentManager(IUniversityDepartmentDal universityDepartmentDal)
        {
            _universityDepartmentDal = universityDepartmentDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(UniversityDepartment universityDepartment)
        {
            IResult result = BusinessRules.Run(IsNameExist(universityDepartment.DepartmentName));

            if (result != null)
            {
                return result;
            }
            _universityDepartmentDal.AddAsync(universityDepartment);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(UniversityDepartment universityDepartment)
        {
            _universityDepartmentDal.UpdateAsync(universityDepartment);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(UniversityDepartment universityDepartment)
        {
            _universityDepartmentDal.Delete(universityDepartment);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(UniversityDepartment universityDepartment)
        {
            _universityDepartmentDal.TerminateSubDatas(universityDepartment.Id);
            _universityDepartmentDal.Terminate(universityDepartment);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        //[SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDepartment>> GetAll()
        {
            return new SuccessDataResult<List<UniversityDepartment>>(_universityDepartmentDal.GetAll().OrderBy(s => s.DepartmentName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDepartment>> GetDeletedAll()
        {
            return new SuccessDataResult<List<UniversityDepartment>>(_universityDepartmentDal.GetDeletedAll().OrderBy(s => s.DepartmentName).ToList(), Messages.SuccessListed);
        }
        //[SecuredOperation("admin,user")]
        public IDataResult<UniversityDepartment> GetById(string id)
        {
            return new SuccessDataResult<UniversityDepartment>(_universityDepartmentDal.Get(f => f.Id == id));
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _universityDepartmentDal.GetAll(c => c.DepartmentName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
