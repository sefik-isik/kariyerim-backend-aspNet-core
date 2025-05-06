using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UniversityDepartmentManager: IUniversityDepartmentService
    {
        IUniversityDepartmentDal _universityDepartmentDal;

        public UniversityDepartmentManager(IUniversityDepartmentDal universityDepartmentDal)
        {
            _universityDepartmentDal = universityDepartmentDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(UniversityDepartment universityDepartment)
        {
            _universityDepartmentDal.Add(universityDepartment);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(UniversityDepartment universityDepartment)
        {
            _universityDepartmentDal.Update(universityDepartment);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(UniversityDepartment universityDepartment)
        {
            _universityDepartmentDal.Delete(universityDepartment);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDepartment>> GetAll()
        {
            return new SuccessDataResult<List<UniversityDepartment>>(_universityDepartmentDal.GetAll());
        }

        [SecuredOperation("admin")]
        public IDataResult<List<UniversityDepartment>> GetDeletedAll()
        {
            return new SuccessDataResult<List<UniversityDepartment>>(_universityDepartmentDal.GetDeletedAll());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<UniversityDepartment> GetById(int universityDepartmentId)
        {
            return new SuccessDataResult<UniversityDepartment>(_universityDepartmentDal.Get(u=>u.Id == universityDepartmentId));
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDepartmentDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<UniversityDepartmentDTO>>(_universityDepartmentDal.GetAllDTO());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDepartmentDTO>> GetAllDeletedDTO()
        {
            return new SuccessDataResult<List<UniversityDepartmentDTO>>(_universityDepartmentDal.GetAllDeletedDTO());
        }

    }
}
