using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Diagnostics.Metrics;
//[PerformanceAspect(5)] AspectInterceptorSelector da tanımlandı 
namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CityValidator))]
        [CacheRemoveAspect()]
        public async Task<IResult> Add(City city)
        {
            IResult result = await BusinessRules.Run(IsNameExist(city.CityName));

            if (result != null)
            {
                return result;
            }

            await _cityDal.AddAsync(city);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect()]
        [ValidationAspect(typeof(CityValidator))]
        public async Task<IResult> Update(City city)
        {
            IResult result = await BusinessRules.Run(IsNameExist(city.CityName));

            if (result != null)
            {
                return result;
            }

            await _cityDal.UpdateAsync(city);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect()]
        public async Task<IResult> Delete(City city)
        {
             await _cityDal.Delete(city);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(City city)
        {
            await _cityDal.TerminateSubDatas(city.Id);
            await _cityDal.Terminate(city);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        //[SecuredOperation("admin,user")]
        //[CacheAspect]
        public async Task<IDataResult<List<City>>> GetAll()
        {
            var result = await _cityDal.GetAll();
            result = result.OrderBy(x => x.CityName).ToList();
            return new SuccessDataResult<List<City>>(result, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public async Task<IDataResult<List<City>>> GetDeletedAll()
        {
            var result = await _cityDal.GetDeletedAll();
            result = result.OrderBy(x => x.CityName).ToList();
            return new SuccessDataResult<List<City>>(result, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public async Task<IDataResult<City?>> GetById(string id)
        {
            var city = await _cityDal.Get(c => c.Id == id);
            return new SuccessDataResult<City?>(city, Messages.SuccessListed);
        }


        //DTO
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CityDTO>>> GetAllDTO()
        {
            var cities = await _cityDal.GetAllDTO();
            return new SuccessDataResult<List<CityDTO>>(cities, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CityDTO>>> GetDeletedAllDTO()
        {
            var cities = await _cityDal.GetDeletedAllDTO();
            return new SuccessDataResult<List<CityDTO>>(cities, Messages.SuccessListed);
        }


        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _cityDal.GetAll(c => c.CityName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}