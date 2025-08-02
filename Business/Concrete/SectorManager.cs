using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SectorManager : ISectorService
    {
        ISectorDal _sectorDal;


        public SectorManager(ISectorDal sectorDal)
        {
            _sectorDal = sectorDal;
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Add(Sector sector)
        {
            IResult result = await BusinessRules.Run(IsNameExist(sector.SectorName));

            if (result != null)
            {
                return result;
            }
            await _sectorDal.AddAsync(sector);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(Sector sector)
        {
            await _sectorDal.UpdateAsync(sector);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(Sector sector)
        {
            await _sectorDal.Delete(sector);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(Sector sector)
        {
            await _sectorDal.Terminate(sector);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Sector>>> GetAll()
        {
            var result = await _sectorDal.GetAll();
            result = result.OrderBy(x => x.SectorName).ToList();
            return new SuccessDataResult<List<Sector>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Sector>>> GetDeletedAll()
        {
            var result = await _sectorDal.GetDeletedAll();
            result = result.OrderBy(x => x.SectorName).ToList();
            return new SuccessDataResult<List<Sector>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<Sector?>> GetById(string id)
        {
            return new SuccessDataResult<Sector?>(await _sectorDal.Get(c=> c.Id == id));
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _sectorDal.GetAll(c => c.SectorName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
