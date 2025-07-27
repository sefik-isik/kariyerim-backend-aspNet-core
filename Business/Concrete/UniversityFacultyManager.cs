using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Business;
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
            IResult result = BusinessRules.Run(IsNameExist(universityFaculty.FacultyName));

            if (result != null)
            {
                return result;
            }
            _universityFacultyDal.AddAsync(universityFaculty);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(UniversityFaculty universityFaculty)
        {
            _universityFacultyDal.UpdateAsync(universityFaculty);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(UniversityFaculty universityFaculty)
        {
            _universityFacultyDal.Delete(universityFaculty);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(UniversityFaculty universityFaculty)
        {
            _universityFacultyDal.Terminate(universityFaculty);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        //[SecuredOperation("admin,user")]
        public IDataResult<List<UniversityFaculty>> GetAll()
        {
            return new SuccessDataResult<List<UniversityFaculty>>(_universityFacultyDal.GetAll().OrderBy(s => s.FacultyName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityFaculty>> GetDeletedAll()
        {
            return new SuccessDataResult<List<UniversityFaculty>>(_universityFacultyDal.GetDeletedAll().OrderBy(s => s.FacultyName).ToList(), Messages.SuccessListed);
        }
        //[SecuredOperation("admin,user")]
        public IDataResult<UniversityFaculty> GetById(string id)
        {
            return new SuccessDataResult<UniversityFaculty>(_universityFacultyDal.Get(l => l.Id == id));
        }
        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _universityFacultyDal.GetAll(c => c.FacultyName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
