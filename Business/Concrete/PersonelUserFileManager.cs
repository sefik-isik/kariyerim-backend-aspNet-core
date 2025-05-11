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
        IPersonelUserService _personelUserService;

        public PersonelUserFileManager(IPersonelUserFileDal personelUserFileDal, IUserService userService)
        {
            _personelUserFileDal = personelUserFileDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserFile personelUserFile)
        {
            _personelUserFileDal.Add(personelUserFile);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserFile personelUserFile)
        {
            _personelUserFileDal.Update(personelUserFile);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserFile personelUserFile)
        {
            _personelUserFileDal.Delete(personelUserFile);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFile>> GetAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFile>>(_personelUserFileDal.GetAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFile>>(_personelUserFileDal.GetAll());
            }
            
        }
        [SecuredOperation("admin")]
        public IDataResult<List<PersonelUserFile>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFile>>(_personelUserFileDal.GetDeletedAll(c => c.PersonelUserId == personelUser.Data.Id));
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

            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserFile>(_personelUserFileDal.Get(c => c.Id == userAdminDTO.Id && c.PersonelUserId == personelUser.Data.Id));
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
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetAllDTO(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFileDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetAllDeletedDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetAllDeletedDTO(), Messages.CompaniesListed);
            }

        }

    }
}
