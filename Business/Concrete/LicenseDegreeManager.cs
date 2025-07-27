using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
        public IResult Add(LicenseDegree licenceDegree)
        {
            IResult result = BusinessRules.Run(IsNameExist(licenceDegree.LicenseDegreeName));

            if (result != null)
            {
                return result;
            }
            _licenseDegreeDal.AddAsync(licenceDegree);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(LicenseDegree licenceDegree)
        {
            _licenseDegreeDal.UpdateAsync(licenceDegree);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(LicenseDegree licenceDegree)
        {
            _licenseDegreeDal.Delete(licenceDegree);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(LicenseDegree licenceDegree)
        {
            _licenseDegreeDal.Terminate(licenceDegree);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<LicenseDegree>> GetAll()
        {
            return new SuccessDataResult<List<LicenseDegree>>(_licenseDegreeDal.GetAll().OrderBy(s => s.LicenseDegreeName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<LicenseDegree>> GetDeletedAll()
        {
            return new SuccessDataResult<List<LicenseDegree>>(_licenseDegreeDal.GetDeletedAll().OrderBy(s => s.LicenseDegreeName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<LicenseDegree> GetById(string id)
        {
            return new SuccessDataResult<LicenseDegree>(_licenseDegreeDal.Get(l=>l.Id == id));
        }
        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _licenseDegreeDal.GetAll(c => c.LicenseDegreeName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
