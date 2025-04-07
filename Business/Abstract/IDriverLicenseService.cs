using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDriverLicenseService
    {
        IResult Add(DriverLicense driverLicense);
        IResult Update(DriverLicense driverLicense);
        IResult Delete(DriverLicense driverLicense);
        IDataResult<List<DriverLicense>> GetAll();
        IDataResult<DriverLicense> GetById(int driverLicenseId);
        
    }
}
