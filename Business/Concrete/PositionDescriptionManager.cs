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
    public class PositionDescriptionManager : IPositionDescriptionService
    {
        IPositionDescriptionDal _positionDescriptionDal;

        public PositionDescriptionManager(IPositionDescriptionDal positionDescriptionDal)
        {
            _positionDescriptionDal = positionDescriptionDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(PositionDescription positionDescription)
        {
            _positionDescriptionDal.AddAsync(positionDescription);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(PositionDescription positionDescription)
        {
            _positionDescriptionDal.UpdateAsync(positionDescription);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(PositionDescription positionDescription)
        {
            _positionDescriptionDal.Delete(positionDescription);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(PositionDescription positionDescription)
        {
            _positionDescriptionDal.Terminate(positionDescription);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PositionDescription>> GetAll()
        {
            return new SuccessDataResult<List<PositionDescription>>(_positionDescriptionDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PositionDescription>> GetDeletedAll()
        {
            return new SuccessDataResult<List<PositionDescription>>(_positionDescriptionDal.GetDeletedAll());
        }
        //[SecuredOperation("admin,user")]
        public IDataResult<PositionDescription> GetById(string id)
        {
            return new SuccessDataResult<PositionDescription>(_positionDescriptionDal.Get(r => r.Id == id));
        }



        //[SecuredOperation("admin,user")]
        public IDataResult<List<PositionDescriptionDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<PositionDescriptionDTO>>(_positionDescriptionDal.GetAllDTO().OrderBy(s => s.PositionName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PositionDescriptionDTO>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<PositionDescriptionDTO>>(_positionDescriptionDal.GetDeletedAllDTO().OrderBy(s => s.PositionName).ToList(), Messages.SuccessListed);
        }
        public IDataResult<List<PositionDescriptionDTO>> GetAllByPositionIdDTO(string id)
        {
            return new SuccessDataResult<List<PositionDescriptionDTO>>(_positionDescriptionDal.GetAllByPositionIdDTO(id));
        }
    }
}
