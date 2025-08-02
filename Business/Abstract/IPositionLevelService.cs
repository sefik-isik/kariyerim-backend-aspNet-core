using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPositionLevelService
    {
        Task<IResult> Add(PositionLevel positionLevel);
        Task<IResult> Update(PositionLevel positionLevel);
        Task<IResult> Delete(PositionLevel positionLevel);
        Task<IResult> Terminate(PositionLevel positionLevel);
        Task<IDataResult<List<PositionLevel>>> GetAll();
        Task<IDataResult<List<PositionLevel>>> GetDeletedAll();
        Task<IDataResult<PositionLevel>> GetById(string id);
    }
}
