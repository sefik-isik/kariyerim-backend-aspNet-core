using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWorkingMethodService
    {
        IResult Add(WorkingMethod workingMethod);
        IResult Update(WorkingMethod workingMethod);
        IResult Delete(WorkingMethod workingMethod);
        IDataResult<List<WorkingMethod>> GetAll();IDataResult<List<WorkingMethod>> GetDeletedAll();
        IDataResult<WorkingMethod> GetById(int workingMethodId);
        
    }
}
