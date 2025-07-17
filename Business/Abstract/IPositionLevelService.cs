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
        IResult Add(PositionLevel positionLevel);
        IResult Update(PositionLevel positionLevel);
        IResult Delete(PositionLevel positionLevel);
        IResult Terminate(PositionLevel positionLevel);
        IDataResult<List<PositionLevel>> GetAll();
        IDataResult<List<PositionLevel>> GetDeletedAll();
        IDataResult<PositionLevel> GetById(string id);
    }
}
