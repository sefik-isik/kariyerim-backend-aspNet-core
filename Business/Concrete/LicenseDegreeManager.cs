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
    public class LicenceDegreeManager : ILicenceDegreeService
    {
        ILicenceDegreeDal _licenceDegreeDal;

        public LicenceDegreeManager(ILicenceDegreeDal licenceDegreeDal)
        {
            _licenceDegreeDal = licenceDegreeDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(LicenceDegree LicenceDegree)
        {
            _licenceDegreeDal.Add(LicenceDegree);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(LicenceDegree LicenceDegree)
        {
            _licenceDegreeDal.Update(LicenceDegree);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(LicenceDegree LicenceDegree)
        {
            _licenceDegreeDal.Delete(LicenceDegree);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<LicenceDegree>> GetAll()
        {
            return new SuccessDataResult<List<LicenceDegree>>(_licenceDegreeDal.GetAll());
        }
        [SecuredOperation("admin")]
        public IDataResult<List<LicenceDegree>> GetDeletedAll()
        {
            return new SuccessDataResult<List<LicenceDegree>>(_licenceDegreeDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<LicenceDegree> GetById(int LicenceDegreeId)
        {
            return new SuccessDataResult<LicenceDegree>(_licenceDegreeDal.Get(l=>l.Id == LicenceDegreeId));
        }

        
    }
}
