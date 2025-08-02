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
        public async Task<IResult> Add(UniversityDescription universityDescription)
        {
            await _universityDescriptionDal.AddAsync(universityDescription);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(UniversityDescription universityDescription)
        {
            await _universityDescriptionDal.UpdateAsync(universityDescription);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(UniversityDescription universityDescription)
        {
            await _universityDescriptionDal.Delete(universityDescription);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(UniversityDescription universityDescription)
        {
            await _universityDescriptionDal.Terminate(universityDescription);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDescription>>> GetAll()
        {
            return new SuccessDataResult<List<UniversityDescription>>(await _universityDescriptionDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDescription>>> GetDeletedAll()
        {
            return new SuccessDataResult<List<UniversityDescription>>(await _universityDescriptionDal.GetDeletedAll());
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<UniversityDescription?>> GetById(string id)
        {
            return new SuccessDataResult<UniversityDescription?>(await _universityDescriptionDal.Get(u=>u.Id == id));
        }

        //DTO
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDescriptionDTO>>> GetAllDTO()
        {
            return new SuccessDataResult<List<UniversityDescriptionDTO>>(await _universityDescriptionDal.GetAllDTO(), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDescriptionDTO>>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<UniversityDescriptionDTO>>(await _universityDescriptionDal.GetDeletedAllDTO(), Messages.SuccessListed);
        }

        public async Task<IDataResult<List<UniversityDescriptionDTO>>> GetAllByUniversityIdDTO(string id)
        {
            return new SuccessDataResult<List<UniversityDescriptionDTO>>(await _universityDescriptionDal.GetAllByUniversityIdDTO(id));
        }
    }
}
