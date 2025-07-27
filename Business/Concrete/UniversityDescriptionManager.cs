using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UniversityDescriptionManager : IUniversityDescriptionService
    {
        IUniversityDescriptionDal _universityDescriptionDal;

        public UniversityDescriptionManager(IUniversityDescriptionDal universityDescriptionDal)
        {
            _universityDescriptionDal = universityDescriptionDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(UniversityDescription universityDescription)
        {
            _universityDescriptionDal.AddAsync(universityDescription);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(UniversityDescription universityDescription)
        {
            _universityDescriptionDal.UpdateAsync(universityDescription);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(UniversityDescription universityDescription)
        {
            _universityDescriptionDal.Delete(universityDescription);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(UniversityDescription universityDescription)
        {
            _universityDescriptionDal.Terminate(universityDescription);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDescription>> GetAll()
        {
            return new SuccessDataResult<List<UniversityDescription>>(_universityDescriptionDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDescription>> GetDeletedAll()
        {
            return new SuccessDataResult<List<UniversityDescription>>(_universityDescriptionDal.GetDeletedAll());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<UniversityDescription> GetById(string id)
        {
            return new SuccessDataResult<UniversityDescription>(_universityDescriptionDal.Get(u=>u.Id == id));
        }

        //DTO
        //[SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDescriptionDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<UniversityDescriptionDTO>>(_universityDescriptionDal.GetAllDTO().OrderBy(s => s.UniversityName).ToList(), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDescriptionDTO>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<UniversityDescriptionDTO>>(_universityDescriptionDal.GetDeletedAllDTO().OrderBy(s => s.UniversityName).ToList(), Messages.SuccessListed);
        }

        public IDataResult<List<UniversityDescriptionDTO>> GetAllByUniversityIdDTO(string id)
        {
            return new SuccessDataResult<List<UniversityDescriptionDTO>>(_universityDescriptionDal.GetAllByUniversityIdDTO(id));
        }
    }
}
