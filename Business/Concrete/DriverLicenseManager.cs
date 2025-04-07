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
    public class DriverLicenseManager : IDriverLicenseService
    {
        IDriverLicenseDal _driverLicenseDal;

        public DriverLicenseManager(IDriverLicenseDal driverLicenseDal)
        {
            _driverLicenseDal = driverLicenseDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(DriverLicense driverLicense)
        {
            _driverLicenseDal.Add(driverLicense);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(DriverLicense driverLicense)
        {
            _driverLicenseDal.Update(driverLicense);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(DriverLicense driverLicense)
        {
            _driverLicenseDal.Delete(driverLicense);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<DriverLicense>> GetAll()
        {
            return new SuccessDataResult<List<DriverLicense>>(_driverLicenseDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<DriverLicense> GetById(int driverLicenseId)
        {
            return new SuccessDataResult<DriverLicense>(_driverLicenseDal.Get(d=> d.Id == driverLicenseId));
        }

        
    }
}
