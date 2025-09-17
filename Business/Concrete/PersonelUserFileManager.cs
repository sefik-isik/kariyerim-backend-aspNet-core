using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
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
    public class PersonelUserFileManager : IPersonelUserFileService
    {
        IPersonelUserFileDal _personelUserFileDal;
        IUserService _userService;

        public PersonelUserFileManager(IPersonelUserFileDal personelUserFileDal, IUserService userService)
        {
            _personelUserFileDal = personelUserFileDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(PersonelUserFile personelUserFile)
        {
            if (_userService.GetById(personelUserFile.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserFileDal.AddAsync(personelUserFile);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(PersonelUserFile personelUserFile)
        {
            if (_userService.GetById(personelUserFile.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserFileDal.UpdateAsync(personelUserFile);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(PersonelUserFile personelUserFile)
        {
            if (_userService.GetById(personelUserFile.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserFileDal.Delete(personelUserFile);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(PersonelUserFile personelUserFile)
        {
            await _personelUserFileDal.Terminate(personelUserFile);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserFile>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFile>>(await _personelUserFileDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFile>>(await _personelUserFileDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserFile>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFile>>(await _personelUserFileDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFile>>(await _personelUserFileDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserFile?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserFile?>(await _personelUserFileDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserFile?>(await _personelUserFileDal.Get(c => c.Id == userAdminDTO.Id));
            }

            
        }

        //DTO
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserFileDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserFileDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.PersonelUserId == userAdminDTO.Id), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserFileDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserFileDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

    }
}
