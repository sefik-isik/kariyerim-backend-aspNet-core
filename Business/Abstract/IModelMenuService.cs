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
        IResult Add(ModelMenu modelMenu);
        IResult Update(ModelMenu modelMenu);
        IResult Delete(ModelMenu modelMenu);
        IDataResult<List<ModelMenu>> GetAll();
        IDataResult<ModelMenu> GetById(int modelMenuId);
    }
}
