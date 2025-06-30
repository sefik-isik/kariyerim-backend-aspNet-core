using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICountryService
    {
        IResult Add(Country country);
        IResult Update(Country country);
        IResult Delete(Country country);
        IResult Terminate(Country country);
        IDataResult<List<Country>> GetAll();
        IDataResult<List<Country>> GetDeletedAll();
        IDataResult<Country> GetById(string id);
        
    }
}
