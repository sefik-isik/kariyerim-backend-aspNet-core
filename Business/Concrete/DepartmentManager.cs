using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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
            _departmentDal.Add(department);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Department department)
        {
            _departmentDal.Update(department);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Department department)
        {
            _departmentDal.Delete(department);
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
        public IDataResult<Department> GetById(int id)
        {
            return new SuccessDataResult<Department>(_departmentDal.Get(f => f.Id == id));
        }
    }
}
