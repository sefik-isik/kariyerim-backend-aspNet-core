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
        public IDataResult<List<PersonelUserFile>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFile>>(_personelUserFileDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFile>>(_personelUserFileDal.GetAll());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserFile> GetById(int personelFileId)
        {
            return new SuccessDataResult<PersonelUserFile>(_personelUserFileDal.Get(c => c.Id == personelFileId));
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFileDTO>> GetPersonelUserFileDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetPersonelUserFileDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetPersonelUserFileDTO(), Messages.CompaniesListed);
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFileDTO>> GetPersonelUserFileDeletedDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetPersonelUserFileDeletedDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFileDTO>>(_personelUserFileDal.GetPersonelUserFileDeletedDTO(), Messages.CompaniesListed);
            }

        }

        
    }
}
