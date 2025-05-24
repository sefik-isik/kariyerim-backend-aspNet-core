using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
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
    public class UniversityFacultyManager : IUniversityFacultyService
    {
        IUniversityFacultyDal _universityFacultyDal;

        public UniversityFacultyManager(IUniversityFacultyDal universityFacultyDal)
        {
            _universityFacultyDal = universityFacultyDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(UniversityFaculty universityFaculty)
        {
            _universityFacultyDal.Add(universityFaculty);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(UniversityFaculty universityFaculty)
        {
            _universityFacultyDal.Update(universityFaculty);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(UniversityFaculty universityFaculty)
        {
            _universityFacultyDal.Delete(universityFaculty);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityFaculty>> GetAll()
        {
            return new SuccessDataResult<List<UniversityFaculty>>(_universityFacultyDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityFaculty>> GetDeletedAll()
        {
            return new SuccessDataResult<List<UniversityFaculty>>(_universityFacultyDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<UniversityFaculty> GetById(int id)
        {
            return new SuccessDataResult<UniversityFaculty>(_universityFacultyDal.Get(r => r.Id == id));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityFacultyDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<UniversityFacultyDTO>>(_universityFacultyDal.GetAllDTO().OrderBy(s => s.UniversityName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityFacultyDTO>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<UniversityFacultyDTO>>(_universityFacultyDal.GetDeletedAllDTO().OrderBy(s => s.UniversityName).ToList());
        }
    }
}
