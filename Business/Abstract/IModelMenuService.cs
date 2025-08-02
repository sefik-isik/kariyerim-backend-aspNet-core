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
    public interface IModelMenuService
    {
        Task<IResult> Add(ModelMenu modelMenu);
        Task<IResult> Update(ModelMenu modelMenu);
        Task<IResult> Delete(ModelMenu modelMenu);
        Task<IResult> Terminate(ModelMenu modelMenu);
        Task<IDataResult<List<ModelMenu>>> GetAll();
        Task<IDataResult<List<ModelMenu>>> GetDeletedAll();
        Task<IDataResult<ModelMenu>> GetById(string id);
    }
}
