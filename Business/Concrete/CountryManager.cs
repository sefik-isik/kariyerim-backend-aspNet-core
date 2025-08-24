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
        public async Task<IResult> Add(Country country)
        {
            IResult result = await BusinessRules.Run(IsNameExist(country.CountryName));

            if (result != null)
            {
                return result;
            }

            await _countryDal.AddAsync(country);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(Country country)
        {
            IResult result = await BusinessRules.Run(IsNameExist(country.CountryName));

            if (result != null)
            {
                return result;
            }
            await _countryDal.UpdateAsync(country);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Delete(Country country)
        {
            await _countryDal.Delete(country);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(Country country)
        {
            await _countryDal.TerminateSubDatas(country.Id);
            await _countryDal.Terminate(country);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Country>>> GetAll()
        {
            var result = await _countryDal.GetAll();
            result = result.OrderBy(x => x.CountryName).ToList();
            return new SuccessDataResult<List<Country>>(result, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Country>>> GetDeletedAll()
        {
            var result = await _countryDal.GetDeletedAll();
            result = result.OrderBy(x => x.CountryName).ToList();
            return new SuccessDataResult<List<Country>>(result, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<Country?>> GetById(string id)
        {
            return new SuccessDataResult<Country?>(await _countryDal.Get(c=> c.Id == id));
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _countryDal.GetAll(c => c.CountryName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }


    }
}
