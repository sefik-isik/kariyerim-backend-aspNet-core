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
    public interface IExperienceService
    {
        IResult Add(Experience experience);
        IResult Update(Experience experience);
        IResult Delete(Experience experience);
        IResult Terminate(Experience experience);
        IDataResult<List<Experience>> GetAll();
        IDataResult<List<Experience>> GetDeletedAll();
        IDataResult<Experience> GetById(string id);
    }
}
