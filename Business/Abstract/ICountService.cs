using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICountService
    {
        Task<IResult> Add(Count count);
        Task<IResult> Update(Count count);
        Task<IResult> Delete(Count count);
        Task<IResult> Terminate(Count count);
        Task<IDataResult<List<Count>>> GetAll();
        Task<IDataResult<List<Count>>> GetDeletedAll();
        Task<IDataResult<Count>> GetById(string id);
    }
}
