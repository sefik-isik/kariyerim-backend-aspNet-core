using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class WorkingMethodManager: IWorkingMethodService
    {
        IWorkingMethodDal _workingMethodDal;

        public WorkingMethodManager(IWorkingMethodDal workingMethodDal)
        {
            _workingMethodDal = workingMethodDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(WorkingMethod workingMethod)
        {
            _workingMethodDal.Add(workingMethod);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(WorkingMethod workingMethod)
        {
            _workingMethodDal.Update(workingMethod);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(WorkingMethod workingMethod)
        {
            _workingMethodDal.Delete(workingMethod);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<WorkingMethod>> GetAll()
        {
            return new SuccessDataResult<List<WorkingMethod>>(_workingMethodDal.GetAll());
        }
        [SecuredOperation("admin")]
        public IDataResult<List<WorkingMethod>> GetDeletedAll()
        {
            return new SuccessDataResult<List<WorkingMethod>>(_workingMethodDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<WorkingMethod> GetById(int workingMethodId)
        {
            return new SuccessDataResult<WorkingMethod>(_workingMethodDal.Get(w=>w.Id == workingMethodId));
        }

        
    }
}
