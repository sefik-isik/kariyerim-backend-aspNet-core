using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
//[PerformanceAspect(5)] AspectInterceptorSelector da tanımlandı 
namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        ICountryService _countryService;

        public CityManager(ICityDal cityDal, ICountryService countryService)
        {
            _cityDal = cityDal;
            _countryService = countryService;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CityValidator))]
        [CacheRemoveAspect()]
        public IResult Add(City city)
        {
            IResult result = BusinessRules.Run(IsCityNameExist(city.CityName));

            if (result != null)
            {
                return result;
            }

            _cityDal.Add(city);
            return new SuccessResult(Messages.SuccessCityAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect()]
        [ValidationAspect(typeof(CityValidator))]
        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult(Messages.SuccessCityUpdated);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect()]
        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult(Messages.SuccessCityDeleted);
        }

        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(), Messages.CitiesListed);
        }

        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public IDataResult<City> GetById(int cityId)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.Id == cityId), Messages.CityListed);
        }


        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CityDTO>> GetCityDTO()
        {
            return new SuccessDataResult<List<CityDTO>>(_cityDal.GetCityDTO(), Messages.CitiesListed);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CityDTO>> GetCityDeletedDTO()
        {
            return new SuccessDataResult<List<CityDTO>>(_cityDal.GetCityDeletedDTO(), Messages.CitiesListed);
        }


        //Business Rules
        private IResult IsCityNameExist(string cityName)
        {
            var result = _cityDal.GetAll(c => c.CityName.ToLower() == cityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}