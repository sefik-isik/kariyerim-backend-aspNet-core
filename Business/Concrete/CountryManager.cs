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
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Core.Utilities.Business;
using Business.Constans;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(Country country)
        {
            IResult result = BusinessRules.Run(IsNameExist(country.CountryName));

            if (result != null)
            {
                return result;
            }

            _countryDal.AddAsync(country);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(Country country)
        {
            IResult result = BusinessRules.Run(IsNameExist(country.CountryName));

            if (result != null)
            {
                return result;
            }
            _countryDal.UpdateAsync(country);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(Country country)
        {
            _countryDal.Delete(country);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(Country country)
        {
            _countryDal.TerminateSubDatas(country.Id);
            _countryDal.Terminate(country);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetAll().OrderBy(s => s.CountryName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Country>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetDeletedAll().OrderBy(s => s.CountryName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Country> GetById(string id)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(c=> c.Id == id));
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _countryDal.GetAll(c => c.CountryName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }


    }
}
