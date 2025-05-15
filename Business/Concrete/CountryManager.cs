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
    public class CountryManager : ICountryService
    {
        ICountryDal _countryDal;

        public CountryManager(ICountryDal country)
        {
            _countryDal = country;
        }
        [SecuredOperation("admin")]
        public IResult Add(Country country)
        {
            _countryDal.Add(country);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Country country)
        {
            _countryDal.Delete(country);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetAll().OrderBy(s => s.CountryName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Country>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetDeletedAll().OrderBy(s => s.CountryName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Country> GetById(int id)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(c=> c.Id == id));
        }
    }
}
