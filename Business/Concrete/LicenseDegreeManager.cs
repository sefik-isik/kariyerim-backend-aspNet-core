using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LicenseDegreeManager : ILicenseDegreeService
    {
        ILicenseDegreeDal _licenseDegreeDal;

        public LicenseDegreeManager(ILicenseDegreeDal licenseDegreeDal)
        {
            _licenseDegreeDal = licenseDegreeDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(LicenseDegree licenseDegree)
        {
            _licenseDegreeDal.Add(licenseDegree);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(LicenseDegree licenseDegree)
        {
            _licenseDegreeDal.Update(licenseDegree);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(LicenseDegree licenseDegree)
        {
            _licenseDegreeDal.Delete(licenseDegree);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<LicenseDegree>> GetAll()
        {
            return new SuccessDataResult<List<LicenseDegree>>(_licenseDegreeDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<LicenseDegree> GetById(int licenseDegreeId)
        {
            return new SuccessDataResult<LicenseDegree>(_licenseDegreeDal.Get(l=>l.Id == licenseDegreeId));
        }

        
    }
}
