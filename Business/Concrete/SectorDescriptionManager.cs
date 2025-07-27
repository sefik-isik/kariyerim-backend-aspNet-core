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
        public IResult Add(SectorDescription sectorDescription)
        {
            _sectorDescriptionDal.AddAsync(sectorDescription);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(SectorDescription sectorDescription)
        {
            _sectorDescriptionDal.UpdateAsync(sectorDescription);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(SectorDescription sectorDescription)
        {
            _sectorDescriptionDal.Delete(sectorDescription);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(SectorDescription sectorDescription)
        {
            _sectorDescriptionDal.Terminate(sectorDescription);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        //[SecuredOperation("admin,user")]
        public IDataResult<List<SectorDescription>> GetAll()
        {
            return new SuccessDataResult<List<SectorDescription>>(_sectorDescriptionDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<SectorDescription>> GetDeletedAll()
        {
            return new SuccessDataResult<List<SectorDescription>>(_sectorDescriptionDal.GetDeletedAll());
        }
        //[SecuredOperation("admin,user")]
        public IDataResult<SectorDescription> GetById(string id)
        {
            return new SuccessDataResult<SectorDescription>(_sectorDescriptionDal.Get(r => r.Id == id));
        }



        //[SecuredOperation("admin,user")]
        public IDataResult<List<SectorDescriptionDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<SectorDescriptionDTO>>(_sectorDescriptionDal.GetAllDTO().OrderBy(s => s.SectorName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<SectorDescriptionDTO>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<SectorDescriptionDTO>>(_sectorDescriptionDal.GetDeletedAllDTO().OrderBy(s => s.SectorName).ToList(), Messages.SuccessListed);
        }
        public IDataResult<List<SectorDescriptionDTO>> GetAllBySectorIdDTO(string id)
        {
            return new SuccessDataResult<List<SectorDescriptionDTO>>(_sectorDescriptionDal.GetAllBySectorIdDTO(id));
        }
    }
}
