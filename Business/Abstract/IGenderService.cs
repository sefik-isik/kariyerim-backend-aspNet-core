using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenderService
    {
        IResult Add(Gender gender);
        IResult Update(Gender gender);
        IResult Delete(Gender gender);
        IDataResult<List<Gender>> GetAll();
        IDataResult<Gender> GetById(int genderId);
        
    }
}
