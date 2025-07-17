using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
        ISectorDal _sectorDal;
        IUserService _userService;

        public SectorManager(ISectorDal sectorDal, IUserService userService)
        {
            _sectorDal = sectorDal;
            _userService = userService;

        }
        [SecuredOperation("admin")]
        public IResult Add(Sector sector)
        {
            IResult result = BusinessRules.Run(IsNameExist(sector.SectorName));

            if (result != null)
            {
                return result;
            }
            _sectorDal.AddAsync(sector);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Sector sector)
        {
            _sectorDal.UpdateAsync(sector);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Sector sector)
        {
            _sectorDal.Delete(sector);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Terminate(Sector sector)
        {
            _sectorDal.Terminate(sector);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<Sector>> GetAll()
        {
            return new SuccessDataResult<List<Sector>>(_sectorDal.GetAll().OrderBy(s => s.SectorName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Sector>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Sector>>(_sectorDal.GetDeletedAll().OrderBy(s => s.SectorName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Sector> GetById(string id)
        {
            return new SuccessDataResult<Sector>(_sectorDal.Get(c=> c.Id == id));
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _sectorDal.GetAll(c => c.SectorName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
