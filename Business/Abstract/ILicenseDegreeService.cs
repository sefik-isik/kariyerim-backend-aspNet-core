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
        IResult Add(LicenseDegree licenseDegree);
        IResult Update(LicenseDegree licenseDegree);
        IResult Delete(LicenseDegree licenseDegree);
        IResult Terminate(LicenseDegree licenseDegree);
        IDataResult<List<LicenseDegree>> GetAll();
        IDataResult<List<LicenseDegree>> GetDeletedAll();
        IDataResult<LicenseDegree> GetById(string id);
        
    }
}
