using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWorkAreaService
    {
        Task<IResult> Add(WorkArea workArea);
        Task<IResult> Update(WorkArea workArea);
        Task<IResult> Delete(WorkArea workArea);
        Task<IResult> Terminate(WorkArea workArea);
        Task<IDataResult<List<WorkArea>>> GetAll();
        Task<IDataResult<List<WorkArea>>> GetDeletedAll();
        Task<IDataResult<WorkArea>> GetById(string id);
    }
}
