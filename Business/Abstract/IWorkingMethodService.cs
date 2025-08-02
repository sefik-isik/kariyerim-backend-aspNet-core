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
        Task<IResult> Add(WorkingMethod workingMethod);
        Task<IResult> Update(WorkingMethod workingMethod);
        Task<IResult> Delete(WorkingMethod workingMethod);
        Task<IResult> Terminate(WorkingMethod workingMethod);
        Task<IDataResult<List<WorkingMethod>>> GetAll();
        Task<IDataResult<List<WorkingMethod>>> GetDeletedAll();
        Task<IDataResult<WorkingMethod>> GetById(string id);
        
    }
}
