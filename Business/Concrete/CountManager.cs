using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
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
    public class CountManager : ICountService
    {
        ICountDal _countDal;

        public CountManager(ICountDal countDal)
        {
            _countDal = countDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(Count count)
        {
            IResult result = BusinessRules.Run(IsNameExist(count.CountValue));

            if (result != null)
            {
                return result;
            }
            _countDal.AddAsync(count);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Count count)
        {
            _countDal.UpdateAsync(count);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Count count)
        {
            _countDal.Delete(count);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Terminate(Count count)
        {
            _countDal.Terminate(count);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Count>> GetAll()
        {
            return new SuccessDataResult<List<Count>>(_countDal.GetAll().OrderBy(s => s.CountValue).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Count>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Count>>(_countDal.GetDeletedAll().OrderBy(s => s.CountValue).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Count> GetById(string id)
        {
            return new SuccessDataResult<Count>(_countDal.Get(l => l.Id == id));
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _countDal.GetAll(c => c.CountValue.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
