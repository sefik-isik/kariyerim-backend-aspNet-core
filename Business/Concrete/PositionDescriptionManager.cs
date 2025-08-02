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
        public async Task<IResult> Add(PositionDescription positionDescription)
        {
            await _positionDescriptionDal.AddAsync(positionDescription);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(PositionDescription positionDescription)
        {
            await _positionDescriptionDal.UpdateAsync(positionDescription);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(PositionDescription positionDescription)
        {
            await _positionDescriptionDal.Delete(positionDescription);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(PositionDescription positionDescription)
        {
            await _positionDescriptionDal.Terminate(positionDescription);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PositionDescription>>> GetAll()
        {
            return new SuccessDataResult<List<PositionDescription>>(await _positionDescriptionDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PositionDescription>>> GetDeletedAll()
        {
            return new SuccessDataResult<List<PositionDescription>>(await _positionDescriptionDal.GetDeletedAll());
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<PositionDescription?>> GetById(string id)
        {
            return new SuccessDataResult<PositionDescription?>(await _positionDescriptionDal.Get(c => c.Id == id));
        }


        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PositionDescriptionDTO>>> GetAllDTO()
        {
            return new SuccessDataResult<List<PositionDescriptionDTO>>(await _positionDescriptionDal.GetAllDTO(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PositionDescriptionDTO>>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<PositionDescriptionDTO>>(await _positionDescriptionDal.GetDeletedAllDTO(), Messages.SuccessListed);
        }
        public async Task<IDataResult<List<PositionDescriptionDTO>>> GetAllByPositionIdDTO(string id)
        {
            return new SuccessDataResult<List<PositionDescriptionDTO>>(await _positionDescriptionDal.GetAllByPositionIdDTO(id));
        }
    }
}
