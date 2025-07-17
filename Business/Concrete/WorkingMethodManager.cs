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
        public IResult Add(WorkingMethod workingMethod)
        {
            IResult result = BusinessRules.Run(IsNameExist(workingMethod.MethodName));

            if (result != null)
            {
                return result;
            }
            _workingMethodDal.AddAsync(workingMethod);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(WorkingMethod workingMethod)
        {
            _workingMethodDal.UpdateAsync(workingMethod);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(WorkingMethod workingMethod)
        {
            _workingMethodDal.Delete(workingMethod);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Terminate(WorkingMethod workingMethod)
        {
            _workingMethodDal.Terminate(workingMethod);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<WorkingMethod>> GetAll()
        {
            return new SuccessDataResult<List<WorkingMethod>>(_workingMethodDal.GetAll().OrderBy(s => s.MethodName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<WorkingMethod>> GetDeletedAll()
        {
            return new SuccessDataResult<List<WorkingMethod>>(_workingMethodDal.GetDeletedAll().OrderBy(s => s.MethodName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<WorkingMethod> GetById(string id)
        {
            return new SuccessDataResult<WorkingMethod>(_workingMethodDal.Get(w=>w.Id == id));
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _workingMethodDal.GetAll(c => c.MethodName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
