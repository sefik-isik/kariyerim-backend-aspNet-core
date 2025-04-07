using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class GenderManager : IGenderService
    {
        IGenderDal _genderDal;

        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(Gender gender)
        {
            _genderDal.Add(gender);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Gender gender)
        {
            _genderDal.Update(gender);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Gender gender)
        {
            _genderDal.Delete(gender);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Gender>> GetAll()
        {
            return new SuccessDataResult<List<Gender>>(_genderDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Gender> GetById(int genderId)
        {
            return new SuccessDataResult<Gender>(_genderDal.Get(g => g.Id == genderId));
        }


    }
}
