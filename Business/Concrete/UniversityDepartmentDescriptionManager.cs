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
        public async Task<IResult> Add(UniversityDepartmentDescription universitydepartmentDescription)
        {
            await _universityDepartmentDescriptionDal.AddAsync(universitydepartmentDescription);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(UniversityDepartmentDescription universitydepartmentDescription)
        {
            await _universityDepartmentDescriptionDal.UpdateAsync(universitydepartmentDescription);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(UniversityDepartmentDescription universitydepartmentDescription)
        {
            await _universityDepartmentDescriptionDal.Delete(universitydepartmentDescription);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(UniversityDepartmentDescription universitydepartmentDescription)
        {
            await _universityDepartmentDescriptionDal.Terminate(universitydepartmentDescription);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDepartmentDescription>>> GetAll()
        {
            return new SuccessDataResult<List<UniversityDepartmentDescription>>(await _universityDepartmentDescriptionDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDepartmentDescription>>> GetDeletedAll()
        {
            return new SuccessDataResult<List<UniversityDepartmentDescription>>(await _universityDepartmentDescriptionDal.GetDeletedAll());
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<UniversityDepartmentDescription?>> GetById(string id)
        {
            return new SuccessDataResult<UniversityDepartmentDescription?>(await _universityDepartmentDescriptionDal.Get(r => r.Id == id));
        }



        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDepartmentDescriptionDTO>>> GetAllDTO()
        {
            return new SuccessDataResult<List<UniversityDepartmentDescriptionDTO>>(await _universityDepartmentDescriptionDal.GetAllDTO(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityDepartmentDescriptionDTO>>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<UniversityDepartmentDescriptionDTO>>(await _universityDepartmentDescriptionDal.GetDeletedAllDTO(), Messages.SuccessListed);
        }
        public async Task<IDataResult<List<UniversityDepartmentDescriptionDTO>>> GetAllByUniversityDeparttmetIdDTO(string id)
        {
            return new SuccessDataResult<List<UniversityDepartmentDescriptionDTO>>(await _universityDepartmentDescriptionDal.GetAllByUniversityDepartmentIdDTO(id));
        }

    }
}
