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
        public async Task<IResult> Add(Region region)
        {
            IResult result = await BusinessRules.Run(IsNameExist(region.RegionName));

            if (result != null)
            {
                return result;
            }
            await _regionDal.AddAsync(region);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(Region region)
        {
            await _regionDal.UpdateAsync(region);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(Region region)
        {
            await _regionDal.Delete(region);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(Region region)
        {
            await _regionDal.Terminate(region);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Region>>> GetAll()
        {
            var result = await _regionDal.GetAll();
            result = result.OrderBy(x => x.RegionName).ToList();
            return new SuccessDataResult<List<Region>>(result);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Region>>> GetDeletedAll()
        {
            var result = await _regionDal.GetDeletedAll();
            result = result.OrderBy(x => x.RegionName).ToList();
            return new SuccessDataResult<List<Region>>(result);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<Region?>> GetById(string id)
        {
            return new SuccessDataResult<Region?>(await _regionDal.Get(r=>r.Id == id));
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<RegionDTO>>> GetAllDTO()
        {
            var result = await _regionDal.GetAllDTO();
            result = result.OrderBy(x => x.RegionName).ToList();
            return new SuccessDataResult<List<RegionDTO>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<RegionDTO>>> GetDeletedAllDTO()
        {
            var result = await _regionDal.GetDeletedAllDTO();
            result = result.OrderBy(x => x.RegionName).ToList();
            return new SuccessDataResult<List<RegionDTO>>(result, Messages.SuccessListed);
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _regionDal.GetAll(c => c.RegionName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
