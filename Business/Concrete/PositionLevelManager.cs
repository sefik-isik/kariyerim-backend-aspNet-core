using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PositionLevelManager : IPositionLevelService
    {
        IPositionLevelDal _positionLevelDal;

        public PositionLevelManager(IPositionLevelDal positionLevelDal)
        {
            _positionLevelDal = positionLevelDal;
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Add(PositionLevel positionLevel)
        {
            IResult result = await BusinessRules.Run(IsNameExist(positionLevel.PositionLevelName));

            if (result != null)
            {
                return result;
            }
            await _positionLevelDal.AddAsync(positionLevel);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(PositionLevel positionLevel)
        {
            await _positionLevelDal.UpdateAsync(positionLevel);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(PositionLevel positionLevel)
        {
            await _positionLevelDal.Delete(positionLevel);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(PositionLevel positionLevel)
        {
            await _positionLevelDal.Terminate(positionLevel);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PositionLevel>>> GetAll()
        {
            var result = await _positionLevelDal.GetAll();
            result = result.OrderBy(x => x.PositionLevelName).ToList();
            return new SuccessDataResult<List<PositionLevel>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PositionLevel>>> GetDeletedAll()
        {
            var result = await _positionLevelDal.GetDeletedAll();
            result = result.OrderBy(x => x.PositionLevelName).ToList();
            return new SuccessDataResult<List<PositionLevel>>(result, Messages.SuccessListed);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<PositionLevel?>> GetById(string id)
        {
            return new SuccessDataResult<PositionLevel?>(await _positionLevelDal.Get(l => l.Id == id));
        }
        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _positionLevelDal.GetAll(c => c.PositionLevelName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
