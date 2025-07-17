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
        IResult Add(Count count);
        IResult Update(Count count);
        IResult Delete(Count count);
        IResult Terminate(Count count);
        IDataResult<List<Count>> GetAll();
        IDataResult<List<Count>> GetDeletedAll();
        IDataResult<Count> GetById(string id);
    }
}
