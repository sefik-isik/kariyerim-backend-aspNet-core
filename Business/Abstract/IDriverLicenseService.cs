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
    public interface IDriverLicenceService
    {
        Task<IResult> Add(DriverLicence driverLicence);
        Task<IResult> Update(DriverLicence driverLicence);
        Task<IResult> Delete(DriverLicence driverLicence);
        Task<IResult> Terminate(DriverLicence driverLicence);
        Task<IDataResult<List<DriverLicence>>> GetAll();
        Task<IDataResult<List<DriverLicence>>> GetDeletedAll();
        Task<IDataResult<DriverLicence>> GetById(string id);
        
    }
}
