using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILicenceDegreeService
    {
        IResult Add(LicenceDegree licenceDegreeId);
        IResult Update(LicenceDegree licenceDegreeId);
        IResult Delete(LicenceDegree licenceDegreeId);
        IDataResult<List<LicenceDegree>> GetAll();
        IDataResult<List<LicenceDegree>> GetDeletedAll();
        IDataResult<LicenceDegree> GetById(int id);
        
    }
}
