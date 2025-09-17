using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
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
    public class PersonelUserCvWorkExperienceManager : IPersonelUserCvWorkExperienceService
    {
        IPersonelUserCvWorkExperienceDal _personelUserCvWorkExperienceDal;
        IUserService _userService;

        public PersonelUserCvWorkExperienceManager(IPersonelUserCvWorkExperienceDal cvWorkExperienceDal, 
            IUserService userService)
        {
            _personelUserCvWorkExperienceDal = cvWorkExperienceDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            if (_userService.GetById(personelUserCvWorkExperience.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCvWorkExperienceDal.AddAsync(personelUserCvWorkExperience); 
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            if (_userService.GetById(personelUserCvWorkExperience.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCvWorkExperienceDal.UpdateAsync(personelUserCvWorkExperience);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            if (_userService.GetById(personelUserCvWorkExperience.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCvWorkExperienceDal.Delete(personelUserCvWorkExperience);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            await _personelUserCvWorkExperienceDal.Terminate(personelUserCvWorkExperience);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvWorkExperience>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(await _personelUserCvWorkExperienceDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(await _personelUserCvWorkExperienceDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvWorkExperience>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(await _personelUserCvWorkExperienceDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(await _personelUserCvWorkExperienceDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserCvWorkExperience?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCvWorkExperience?>(await _personelUserCvWorkExperienceDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCvWorkExperience?>(await _personelUserCvWorkExperienceDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvWorkExperienceDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserCvWorkExperienceDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.CvId == userAdminDTO.Id), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvWorkExperienceDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserCvWorkExperienceDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

    }
}
