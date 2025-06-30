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
        public IResult Add(City city)
        {
            IResult result = BusinessRules.Run(IsCityNameExist(city.CityName));

            if (result != null)
            {
                return result;
            }

            _cityDal.AddAsync(city);
            return new SuccessResult(Messages.SuccessCityAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect()]
        [ValidationAspect(typeof(CityValidator))]
        public IResult Update(City city)
        {
            _cityDal.UpdateAsync(city);
            return new SuccessResult(Messages.SuccessCityUpdated);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect()]
        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult(Messages.SuccessCityDeleted);
        }

        [SecuredOperation("admin")]
        public IResult Terminate(City city)
        {
            _cityDal.TerminateSubDatas(city.Id);
            _cityDal.Terminate(city);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll().OrderBy(s => s.CityName).ToList(), Messages.CitiesListed);
        }

        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public IDataResult<List<City>> GetDeletedAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetDeletedAll().OrderBy(s => s.CityName).ToList(), Messages.CitiesListed);
        }

        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public IDataResult<City> GetById(string id)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.Id == id), Messages.CityListed);
        }


        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CityDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<CityDTO>>(_cityDal.GetAllDTO().OrderBy(s => s.CityName).ToList(), Messages.CitiesListed);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CityDTO>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<CityDTO>>(_cityDal.GetDeletedAllDTO().OrderBy(s => s.CityName).ToList(), Messages.CitiesListed);
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