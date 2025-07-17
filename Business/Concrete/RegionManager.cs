using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
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
    public class RegionManager : IRegionService
    {
        IRegionDal _regionDal;

        public RegionManager(IRegionDal regionDal)
        {
            _regionDal = regionDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(Region region)
        {
            IResult result = BusinessRules.Run(IsNameExist(region.RegionName));

            if (result != null)
            {
                return result;
            }
            _regionDal.AddAsync(region);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Region region)
        {
            _regionDal.UpdateAsync(region);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Region region)
        {
            _regionDal.Delete(region);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Terminate(Region region)
        {
            _regionDal.Terminate(region);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<Region>> GetAll()
        {
            return new SuccessDataResult<List<Region>>(_regionDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<Region>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Region>>(_regionDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Region> GetById(string id)
        {
            return new SuccessDataResult<Region>(_regionDal.Get(r=>r.Id == id));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<RegionDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<RegionDTO>>(_regionDal.GetAllDTO().OrderBy(s => s.CityName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<RegionDTO>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<RegionDTO>>(_regionDal.GetDeletedAllDTO().OrderBy(s => s.CityName).ToList());
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _regionDal.GetAll(c => c.RegionName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
