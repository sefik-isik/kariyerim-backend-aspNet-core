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
    public class PersonelUserCvEducationManager : IPersonelUserCvEducationService
    {
        IPersonelUserCvEducationDal _personelUserCvEducationDal;
        IUserService _userService;

        public PersonelUserCvEducationManager(IPersonelUserCvEducationDal cvEducationDal, IUserService userService)
        {
            _personelUserCvEducationDal = cvEducationDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(PersonelUserCvEducation personelUserCvEducation)
        {
            if (_userService.GetById(personelUserCvEducation.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCvEducationDal.AddAsync(personelUserCvEducation);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(PersonelUserCvEducation personelUserCvEducation)
        {
            if (_userService.GetById(personelUserCvEducation.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCvEducationDal.UpdateAsync(personelUserCvEducation);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(PersonelUserCvEducation personelUserCvEducation)
        {
            if (_userService.GetById(personelUserCvEducation.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCvEducationDal.Delete(personelUserCvEducation);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(PersonelUserCvEducation personelUserCvEducation)
        {
            await _personelUserCvEducationDal.Terminate(personelUserCvEducation);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvEducation>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(await _personelUserCvEducationDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(await _personelUserCvEducationDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvEducation>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(await _personelUserCvEducationDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(await _personelUserCvEducationDal.GetDeletedAll());
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvEducation>>> GetPersonelUser(UserAdminDTO userAdminDTO)
        {

            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(await _personelUserCvEducationDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(await _personelUserCvEducationDal.GetDeletedAll());
            }

        }


        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserCvEducation?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCvEducation?>(await _personelUserCvEducationDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCvEducation?>(await _personelUserCvEducationDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }


        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvEducationDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserCvEducationDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvEducationDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserCvEducationDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }
    }
}
