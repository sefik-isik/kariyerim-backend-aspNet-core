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
        IResult Add(WorkArea workArea);
        IResult Update(WorkArea workArea);
        IResult Delete(WorkArea workArea);
        IResult Terminate(WorkArea workArea);
        IDataResult<List<WorkArea>> GetAll();
        IDataResult<List<WorkArea>> GetDeletedAll();
        IDataResult<WorkArea> GetById(string id);
    }
}
