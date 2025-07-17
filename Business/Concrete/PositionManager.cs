using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Results;
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
    public class PositionManager : IPositionService
    {
        IPositionDal _positionDal;

        public PositionManager(IPositionDal positionDal)
        {
            _positionDal = positionDal;
        }


        [SecuredOperation("admin")]
        public IResult Add(Position position)
        {
            IResult result = BusinessRules.Run(IsNameExist(position.PositionName));

            if (result != null)
            {
                return result;
            }
            _positionDal.AddAsync(position);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Position position)
        {
            _positionDal.UpdateAsync(position);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Position position)
        {
            _positionDal.Delete(position);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Terminate(Position position)
        {
            _positionDal.Terminate(position);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Position>> GetAll()
        {
            return new SuccessDataResult<List<Position>>(_positionDal.GetAll().OrderBy(s => s.PositionName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Position>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Position>>(_positionDal.GetDeletedAll().OrderBy(s => s.PositionName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Position> GetById(string id)
        {
            return new SuccessDataResult<Position>(_positionDal.Get(l => l.Id == id));
        }
        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _positionDal.GetAll(c => c.PositionName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}