using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
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
    public class SectorManager : ISectorService
    {
        ISectorDal _companyUserSectorDal;
        IUserService _userService;

        public SectorManager(ISectorDal companyUserSector, IUserService userService)
        {
            _companyUserSectorDal = companyUserSector;
            _userService = userService;

        }
        [SecuredOperation("admin")]
        public IResult Add(Sector sector)
        {
            _companyUserSectorDal.Add(sector);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Sector sector)
        {
            _companyUserSectorDal.Update(sector);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Sector sector)
        {
            _companyUserSectorDal.Delete(sector);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Sector>> GetAll()
        {
            return new SuccessDataResult<List<Sector>>(_companyUserSectorDal.GetAll().OrderBy(s => s.SectorName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Sector>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Sector>>(_companyUserSectorDal.GetDeletedAll().OrderBy(s => s.SectorName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Sector> GetById(int id)
        {
            return new SuccessDataResult<Sector>(_companyUserSectorDal.Get(c=> c.Id == id));
        }

    }
}
