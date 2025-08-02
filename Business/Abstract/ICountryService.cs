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
        Task<IResult> Add(Country country);
        Task<IResult> Update(Country country);
        Task<IResult> Delete(Country country);
        Task<IResult> Terminate(Country country);
        Task<IDataResult<List<Country>>> GetAll();
        Task<IDataResult<List<Country>>> GetDeletedAll();
        Task<IDataResult<Country>> GetById(string id);
        
    }
}
