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
        public IResult Add(PersonelUserFile personelUserFile)
        {
            if (_userService.GetById(personelUserFile.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserFileDal.AddAsync(personelUserFile);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserFile personelUserFile)
        {
            if (_userService.GetById(personelUserFile.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserFileDal.UpdateAsync(personelUserFile);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserFile personelUserFile)
        {
            if (_userService.GetById(personelUserFile.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserFileDal.Delete(personelUserFile);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Terminate(PersonelUserFile personelUserFile)
        {
            _personelUserFileDal.Terminate(personelUserFile);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFile>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFile>>(_personelUserFileDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFile>>(_personelUserFileDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFile>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFile>>(_personelUserFileDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFile>>(_personelUserFileDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserFile> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserFile>(_personelUserFileDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserFile>(_personelUserFileDal.Get(c => c.Id == userAdminDTO.Id));
            }

            
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFileDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFileDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }

        }

    }
}
