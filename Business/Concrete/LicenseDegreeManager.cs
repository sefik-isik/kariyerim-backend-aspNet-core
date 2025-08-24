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
        public async Task<IResult> Add(LicenseDegree licenceDegree)
        {
            IResult result = await BusinessRules.Run(IsNameExist(licenceDegree.LicenseDegreeName));

            if (result != null)
            {
                return result;
            }
            await _licenseDegreeDal.AddAsync(licenceDegree);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(LicenseDegree licenceDegree)
        {
            await _licenseDegreeDal.UpdateAsync(licenceDegree);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(LicenseDegree licenceDegree)
        {
            await _licenseDegreeDal.Delete(licenceDegree);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(LicenseDegree licenceDegree)
        {
            await _licenseDegreeDal.Terminate(licenceDegree);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<LicenseDegree>>> GetAll()
        {
            var result = await _licenseDegreeDal.GetAll();
            result = result.OrderBy(x => x.LicenseDegreeName).ToList();
            return new SuccessDataResult<List<LicenseDegree>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<LicenseDegree>>> GetDeletedAll()
        {
            var result = await _licenseDegreeDal.GetDeletedAll();
            result = result.OrderBy(x => x.LicenseDegreeName).ToList();
            return new SuccessDataResult<List<LicenseDegree>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<LicenseDegree?>> GetById(string id)
        {
            return new SuccessDataResult<LicenseDegree?>(await _licenseDegreeDal.Get(l=>l.Id == id));
        }
        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _licenseDegreeDal.GetAll(c => c.LicenseDegreeName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
