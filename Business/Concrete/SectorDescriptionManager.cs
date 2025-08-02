using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SectorDescriptionManager : ISectorDescriptionService
    {
        ISectorDescriptionDal _sectorDescriptionDal;

        public SectorDescriptionManager(ISectorDescriptionDal sectorDescriptionDal)
        {
            _sectorDescriptionDal = sectorDescriptionDal;
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Add(SectorDescription sectorDescription)
        {
            await _sectorDescriptionDal.AddAsync(sectorDescription);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(SectorDescription sectorDescription)
        {
            await _sectorDescriptionDal.UpdateAsync(sectorDescription);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(SectorDescription sectorDescription)
        {
            await _sectorDescriptionDal.Delete(sectorDescription);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(SectorDescription sectorDescription)
        {
            await _sectorDescriptionDal.Terminate(sectorDescription);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<SectorDescription>>> GetAll()
        {
            return new SuccessDataResult<List<SectorDescription>>(await _sectorDescriptionDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<SectorDescription>>> GetDeletedAll()
        {
            return new SuccessDataResult<List<SectorDescription>>(await _sectorDescriptionDal.GetDeletedAll());
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<SectorDescription?>> GetById(string id)
        {
            return new SuccessDataResult<SectorDescription?>(await _sectorDescriptionDal.Get(r => r.Id == id));
        }



        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<SectorDescriptionDTO>>> GetAllDTO()
        {
            return new SuccessDataResult<List<SectorDescriptionDTO>>(await _sectorDescriptionDal.GetAllDTO(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<SectorDescriptionDTO>>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<SectorDescriptionDTO>>(await _sectorDescriptionDal.GetDeletedAllDTO(), Messages.SuccessListed);
        }
        public async Task<IDataResult<List<SectorDescriptionDTO>>> GetAllBySectorIdDTO(string id)
        {
            return new SuccessDataResult<List<SectorDescriptionDTO>>(await _sectorDescriptionDal.GetAllBySectorIdDTO(id));
        }
    }
}
