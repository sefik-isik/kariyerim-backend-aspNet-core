using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILicenseDegreeService
    {
        Task<IResult> Add(LicenseDegree licenseDegree);
        Task<IResult> Update(LicenseDegree licenseDegree);
        Task<IResult> Delete(LicenseDegree licenseDegree);
        Task<IResult> Terminate(LicenseDegree licenseDegree);
        Task<IDataResult<List<LicenseDegree>>> GetAll();
        Task<IDataResult<List<LicenseDegree>>> GetDeletedAll();
        Task<IDataResult<LicenseDegree>> GetById(string id);
        
    }
}
