using Core.Utilities.Results;
using Entities.Concrete;
using Entities.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPositionService
    {
        Task<IResult> Add(Position position);
        Task<IResult> Update(Position position);
        Task<IResult> Delete(Position position);
        Task<IResult> Terminate(Position position);
        Task<IDataResult<List<Position>>> GetAll();
        Task<IDataResult<List<Position>>> GetDeletedAll();
        Task<IDataResult<Position>> GetById(string id);
        Task<IDataResult<PositionPageModel>> GetAllByPage(PositionPageModel pageModel);
    }
}
