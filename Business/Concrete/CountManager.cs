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
        public async Task<IResult> Add(Count count)
        {
            IResult result = await BusinessRules.Run(IsNameExist(count.CountValue));

            if (result != null)
            {
                return result;
            }
            await _countDal.AddAsync(count);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(Count count)
        {
            await _countDal.UpdateAsync(count);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(Count count)
        {
            await _countDal.Delete(count);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(Count count)
        {
            await _countDal.Terminate(count);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Count>>> GetAll()
        {
            var result = await _countDal.GetAll();
            result = result.OrderBy(x => x.Order).ToList();
            return new SuccessDataResult<List<Count>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Count>>> GetDeletedAll()
        {
            var result = await _countDal.GetDeletedAll();
            result = result.OrderBy(x => x.Order).ToList();
            return new SuccessDataResult<List<Count>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<Count?>> GetById(string id)
        {
            return new SuccessDataResult<Count?>(await _countDal.Get(l => l.Id == id));
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _countDal.GetAll(c => c.CountValue.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
