using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICountryService
    {
        IResult Add(Country country);
        IResult Update(Country country);
        IResult Delete(Country country);
        IDataResult<List<Country>> GetAll();IDataResult<List<Country>> GetDeletedAll();
        IDataResult<Country> GetById(int UserId);
        
    }
}
