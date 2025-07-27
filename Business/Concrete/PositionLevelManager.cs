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
        public IResult Add(PositionLevel positionLevel)
        {
            IResult result = BusinessRules.Run(IsNameExist(positionLevel.PositionLevelName));

            if (result != null)
            {
                return result;
            }
            _positionLevelDal.AddAsync(positionLevel);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(PositionLevel positionLevel)
        {
            _positionLevelDal.UpdateAsync(positionLevel);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(PositionLevel positionLevel)
        {
            _positionLevelDal.Delete(positionLevel);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(PositionLevel positionLevel)
        {
            _positionLevelDal.Terminate(positionLevel);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PositionLevel>> GetAll()
        {
            return new SuccessDataResult<List<PositionLevel>>(_positionLevelDal.GetAll().OrderBy(s => s.PositionLevelName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PositionLevel>> GetDeletedAll()
        {
            return new SuccessDataResult<List<PositionLevel>>(_positionLevelDal.GetDeletedAll().OrderBy(s => s.PositionLevelName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<PositionLevel> GetById(string id)
        {
            return new SuccessDataResult<PositionLevel>(_positionLevelDal.Get(l => l.Id == id));
        }
        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _positionLevelDal.GetAll(c => c.PositionLevelName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
