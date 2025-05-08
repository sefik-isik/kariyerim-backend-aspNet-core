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
    public class UniversityManager: IUniversityService
    {
        IUniversityDal _universityDal;

        public UniversityManager(IUniversityDal universityDal)
        {
            _universityDal = universityDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(University university)
        {
            _universityDal.Add(university);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(University university)
        {
            _universityDal.Update(university);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(University university)
        {
            _universityDal.Delete(university);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<University>> GetAll()
        {
            return new SuccessDataResult<List<University>>(_universityDal.GetAll());
        }

        [SecuredOperation("admin")]
        public IDataResult<List<University>> GetDeletedAll()
        {
            return new SuccessDataResult<List<University>>(_universityDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<University> GetById(int id)
        {
            return new SuccessDataResult<University>(_universityDal.Get(u=>u.Id == id));
        }

        
    }
}
