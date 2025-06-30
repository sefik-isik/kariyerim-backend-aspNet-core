using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
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
    public  class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(Department department)
        {
            _departmentDal.AddAsync(department);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Department department)
        {
            _departmentDal.UpdateAsync(department);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Department department)
        {
            _departmentDal.Delete(department);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Terminate(Department department)
        {
            _departmentDal.TerminateSubDatas(department.Id);
            _departmentDal.Terminate(department);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<Department>> GetAll()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll().OrderBy(s => s.DepartmentName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Department>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetDeletedAll().OrderBy(s => s.DepartmentName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Department> GetById(string id)
        {
            return new SuccessDataResult<Department>(_departmentDal.Get(f => f.Id == id));
        }
    }
}
