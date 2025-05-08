using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDriverLicenceService
    {
        IResult Add(DriverLicence driverLicence);
        IResult Update(DriverLicence driverLicence);
        IResult Delete(DriverLicence driverLicence);
        IDataResult<List<DriverLicence>> GetAll();
        IDataResult<List<DriverLicence>> GetDeletedAll();
        IDataResult<DriverLicence> GetById(int id);
        
    }
}
