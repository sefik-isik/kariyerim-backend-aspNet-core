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
    public class WorkingMethodManager: IWorkingMethodService
    {
        IWorkingMethodDal _workingMethodDal;

        public WorkingMethodManager(IWorkingMethodDal workingMethodDal)
        {
            _workingMethodDal = workingMethodDal;
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Add(WorkingMethod workingMethod)
        {
            IResult result = await BusinessRules.Run(IsNameExist(workingMethod.MethodName));

            if (result != null)
            {
                return result;
            }
            await _workingMethodDal.AddAsync(workingMethod);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(WorkingMethod workingMethod)
        {
            await _workingMethodDal.UpdateAsync(workingMethod);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(WorkingMethod workingMethod)
        {
            await _workingMethodDal.Delete(workingMethod);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(WorkingMethod workingMethod)
        {
            await _workingMethodDal.Terminate(workingMethod);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<WorkingMethod>>> GetAll()
        {
            var result = await _workingMethodDal.GetAll();
            result = result.OrderBy(x => x.MethodName).ToList();
            return new SuccessDataResult<List<WorkingMethod>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<WorkingMethod>>> GetDeletedAll()
        {
            var result = await _workingMethodDal.GetDeletedAll();
            result = result.OrderBy(x => x.MethodName).ToList();
            return new SuccessDataResult<List<WorkingMethod>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<WorkingMethod?>> GetById(string id)
        {
            return new SuccessDataResult<WorkingMethod?>(await _workingMethodDal.Get(w=>w.Id == id));
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _workingMethodDal.GetAll(c => c.MethodName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
