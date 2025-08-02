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
    public class WorkAreaManager : IWorkAreaService
    {
        IWorkAreaDal _workAreaDal;
        public WorkAreaManager(IWorkAreaDal workAreaDal)
        {
            _workAreaDal = workAreaDal;
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Add(WorkArea workArea)
        {
            IResult result = await BusinessRules.Run(IsNameExist(workArea.AreaName));

            if (result != null)
            {
                return result;
            }
            await _workAreaDal.AddAsync(workArea);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(WorkArea workArea)
        {
            await _workAreaDal.UpdateAsync(workArea);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(WorkArea workArea)
        {
            await _workAreaDal.Delete(workArea);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(WorkArea workArea)
        {
            await _workAreaDal.Terminate(workArea);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<WorkArea>>> GetAll()
        {
            var result = await _workAreaDal.GetAll();
            result = result.OrderBy(x => x.AreaName).ToList();
            return new SuccessDataResult<List<WorkArea>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<WorkArea>>> GetDeletedAll()
        {
            var result = await _workAreaDal.GetDeletedAll();
            result = result.OrderBy(x => x.AreaName).ToList();
            return new SuccessDataResult<List<WorkArea>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<WorkArea?>> GetById(string id)
        {
            return new SuccessDataResult<WorkArea?>(await _workAreaDal.Get(f => f.Id == id));
        }
        
        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {

            var result = await _workAreaDal.GetAll(c => c.AreaName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
