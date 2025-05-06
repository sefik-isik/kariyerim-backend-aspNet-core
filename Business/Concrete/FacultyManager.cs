using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FacultyManager : IFacultyService
    {
        IFacultyDal _facultyDal;

        public FacultyManager(IFacultyDal facultyDal)
        {
            _facultyDal = facultyDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(Faculty faculty)
        {
            _facultyDal.Add(faculty);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Faculty faculty)
        {
            _facultyDal.Update(faculty);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Faculty faculty)
        {
            _facultyDal.Delete(faculty);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Faculty>> GetAll()
        {
            return new SuccessDataResult<List<Faculty>>(_facultyDal.GetAll());
        }
        [SecuredOperation("admin")]
        public IDataResult<List<Faculty>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Faculty>>(_facultyDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Faculty> GetById(int facultyId)
        {
            return new SuccessDataResult<Faculty>(_facultyDal.Get(f => f.Id == facultyId));
        }


    }
}
