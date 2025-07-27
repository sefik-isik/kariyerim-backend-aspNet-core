using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UniversityDepartmentDescriptionManager : IUniversityDepartmentDescriptionService
    {
        IUniversityDepartmentDescriptionDal _universityDepartmentDescriptionDal;

        public UniversityDepartmentDescriptionManager(IUniversityDepartmentDescriptionDal universityDepartmentDescriptionDal)
        {
            _universityDepartmentDescriptionDal = universityDepartmentDescriptionDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(UniversityDepartmentDescription universitydepartmentDescription)
        {
            _universityDepartmentDescriptionDal.AddAsync(universitydepartmentDescription);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(UniversityDepartmentDescription universitydepartmentDescription)
        {
            _universityDepartmentDescriptionDal.UpdateAsync(universitydepartmentDescription);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(UniversityDepartmentDescription universitydepartmentDescription)
        {
            _universityDepartmentDescriptionDal.Delete(universitydepartmentDescription);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(UniversityDepartmentDescription universitydepartmentDescription)
        {
            _universityDepartmentDescriptionDal.Terminate(universitydepartmentDescription);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDepartmentDescription>> GetAll()
        {
            return new SuccessDataResult<List<UniversityDepartmentDescription>>(_universityDepartmentDescriptionDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDepartmentDescription>> GetDeletedAll()
        {
            return new SuccessDataResult<List<UniversityDepartmentDescription>>(_universityDepartmentDescriptionDal.GetDeletedAll());
        }
        //[SecuredOperation("admin,user")]
        public IDataResult<UniversityDepartmentDescription> GetById(string id)
        {
            return new SuccessDataResult<UniversityDepartmentDescription>(_universityDepartmentDescriptionDal.Get(r => r.Id == id));
        }

       

        //[SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDepartmentDescriptionDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<UniversityDepartmentDescriptionDTO>>(_universityDepartmentDescriptionDal.GetAllDTO().OrderBy(s => s.DepartmentName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDepartmentDescriptionDTO>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<UniversityDepartmentDescriptionDTO>>(_universityDepartmentDescriptionDal.GetDeletedAllDTO().OrderBy(s => s.DepartmentName).ToList(), Messages.SuccessListed);
        }
        public IDataResult<List<UniversityDepartmentDescriptionDTO>> GetAllByUniversityDeparttmetIdDTO(string id)
        {
            return new SuccessDataResult<List<UniversityDepartmentDescriptionDTO>>(_universityDepartmentDescriptionDal.GetAllByUniversityDepartmentIdDTO(id));
        }

    }
}
