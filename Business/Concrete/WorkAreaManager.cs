using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
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
        public IResult Add(WorkArea workArea)
        {
            _workAreaDal.AddAsync(workArea);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(WorkArea workArea)
        {
            _workAreaDal.UpdateAsync(workArea);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(WorkArea workArea)
        {
            _workAreaDal.Delete(workArea);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Terminate(WorkArea workArea)
        {
            _workAreaDal.Terminate(workArea);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<WorkArea>> GetAll()
        {
            return new SuccessDataResult<List<WorkArea>>(_workAreaDal.GetAll().OrderBy(s => s.AreaName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<WorkArea>> GetDeletedAll()
        {
            return new SuccessDataResult<List<WorkArea>>(_workAreaDal.GetDeletedAll().OrderBy(s => s.AreaName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<WorkArea> GetById(string id)
        {
            return new SuccessDataResult<WorkArea>(_workAreaDal.Get(f => f.Id == id));
        }
    }
}
