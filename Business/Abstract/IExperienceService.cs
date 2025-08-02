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
        Task<IResult> Add(Experience experience);
        Task<IResult> Update(Experience experience);
        Task<IResult> Delete(Experience experience);
        Task<IResult> Terminate(Experience experience);
        Task<IDataResult<List<Experience>>> GetAll();
        Task<IDataResult<List<Experience>>> GetDeletedAll();
        Task<IDataResult<Experience>> GetById(string id);
    }
}
