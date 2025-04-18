using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class DriverLicenceManager : IDriverLicenceService
    {
        IDriverLicenceDal _driverLicenceDal;

        public DriverLicenceManager(IDriverLicenceDal driverLicenceDal)
        {
            _driverLicenceDal = driverLicenceDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(DriverLicence driverLicence)
        {
            _driverLicenceDal.Add(driverLicence);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(DriverLicence driverLicence)
        {
            _driverLicenceDal.Update(driverLicence);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(DriverLicence driverLicence)
        {
            _driverLicenceDal.Delete(driverLicence);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<DriverLicence>> GetAll()
        {
            return new SuccessDataResult<List<DriverLicence>>(_driverLicenceDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<DriverLicence> GetById(int driverLicenceId)
        {
            return new SuccessDataResult<DriverLicence>(_driverLicenceDal.Get(d=> d.Id == driverLicenceId));
        }

        
    }
}
