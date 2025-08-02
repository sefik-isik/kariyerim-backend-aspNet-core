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
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Core.Utilities.Business;
using Business.Constans;

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
        public async Task<IResult> Add(DriverLicence driverLicence)
        {
            IResult result = await BusinessRules.Run(IsNameExist(driverLicence.DriverLicenceName));

            if (result != null)
            {
                return result;
            }
           await _driverLicenceDal.AddAsync(driverLicence);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(DriverLicence driverLicence)
        {
           await _driverLicenceDal.UpdateAsync(driverLicence);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(DriverLicence driverLicence)
        {
           await _driverLicenceDal.Delete(driverLicence);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(DriverLicence driverLicence)
        {
            await _driverLicenceDal.Terminate(driverLicence);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<DriverLicence>>> GetAll()
        {
            var result = await _driverLicenceDal.GetAll();
            result = result.OrderBy(x => x.DriverLicenceName).ToList();
            return new SuccessDataResult<List<DriverLicence>>(result, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<DriverLicence>>> GetDeletedAll()
        {
            var result = await _driverLicenceDal.GetDeletedAll();
            result = result.OrderBy(x => x.DriverLicenceName).ToList();
            return new SuccessDataResult<List<DriverLicence>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<DriverLicence?>> GetById(string id)
        {
            return new SuccessDataResult<DriverLicence?>(await _driverLicenceDal.Get(d=> d.Id == id));
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _driverLicenceDal.GetAll(c => c.DriverLicenceName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
