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
        public IResult Add(DriverLicence driverLicence)
        {
            IResult result = BusinessRules.Run(IsNameExist(driverLicence.DriverLicenceName));

            if (result != null)
            {
                return result;
            }
            _driverLicenceDal.AddAsync(driverLicence);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(DriverLicence driverLicence)
        {
            _driverLicenceDal.UpdateAsync(driverLicence);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(DriverLicence driverLicence)
        {
            _driverLicenceDal.Delete(driverLicence);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(DriverLicence driverLicence)
        {
            _driverLicenceDal.Terminate(driverLicence);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<DriverLicence>> GetAll()
        {
            return new SuccessDataResult<List<DriverLicence>>(_driverLicenceDal.GetAll().OrderBy(s => s.DriverLicenceName).ToList(), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<DriverLicence>> GetDeletedAll()
        {
            return new SuccessDataResult<List<DriverLicence>>(_driverLicenceDal.GetDeletedAll().OrderBy(s => s.DriverLicenceName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<DriverLicence> GetById(string id)
        {
            return new SuccessDataResult<DriverLicence>(_driverLicenceDal.Get(d=> d.Id == id));
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _driverLicenceDal.GetAll(c => c.DriverLicenceName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
