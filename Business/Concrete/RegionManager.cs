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
            _regionDal.Add(region);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Region region)
        {
            _regionDal.Update(region);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Region region)
        {
            _regionDal.Delete(region);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Region>> GetAll()
        {
            return new SuccessDataResult<List<Region>>(_regionDal.GetAll());
        }
        [SecuredOperation("admin")]
        public IDataResult<List<Region>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Region>>(_regionDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Region> GetById(int id)
        {
            return new SuccessDataResult<Region>(_regionDal.Get(r=>r.Id == id));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<RegionDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<RegionDTO>>(_regionDal.GetAllDTO());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<RegionDTO>> GetAllDeletedDTO()
        {
            return new SuccessDataResult<List<RegionDTO>>(_regionDal.GetAllDeletedDTO());
        }
    }
}
