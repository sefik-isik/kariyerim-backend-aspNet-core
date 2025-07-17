using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DepartmentDescriptionManager: IDepartmentDescriptionService
    {
        IDepartmentDescriptionDal _departmentDescriptionDal;

        public DepartmentDescriptionManager(IDepartmentDescriptionDal departmentDescriptionDal)
        {
            _departmentDescriptionDal = departmentDescriptionDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(DepartmentDescription departmentDescription)
        {
            _departmentDescriptionDal.AddAsync(departmentDescription);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(DepartmentDescription departmentDescription)
        {
            _departmentDescriptionDal.UpdateAsync(departmentDescription);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(DepartmentDescription departmentDescription)
        {
            _departmentDescriptionDal.Delete(departmentDescription);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Terminate(DepartmentDescription departmentDescription)
        {
            _departmentDescriptionDal.Terminate(departmentDescription);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<DepartmentDescription>> GetAll()
        {
            return new SuccessDataResult<List<DepartmentDescription>>(_departmentDescriptionDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<DepartmentDescription>> GetDeletedAll()
        {
            return new SuccessDataResult<List<DepartmentDescription>>(_departmentDescriptionDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<DepartmentDescription> GetById(string id)
        {
            return new SuccessDataResult<DepartmentDescription>(_departmentDescriptionDal.Get(r => r.Id == id));
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<DepartmentDescriptionDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<DepartmentDescriptionDTO>>(_departmentDescriptionDal.GetAllDTO().OrderBy(s => s.DepartmentName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<DepartmentDescriptionDTO>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<DepartmentDescriptionDTO>>(_departmentDescriptionDal.GetDeletedAllDTO().OrderBy(s => s.DepartmentName).ToList());
        }



    }
}
