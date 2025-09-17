using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
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
    public class PersonelUserAdvertApplicationManager : IPersonelUserAdvertApplicationService
    {
        IPersonelUserAdvertApplicationDal _personelUseradvertApplicationDal;
        IUserService _userService;
        public PersonelUserAdvertApplicationManager(IPersonelUserAdvertApplicationDal personelUseradvertApplicationDal, IUserService userService)
        {
            _personelUseradvertApplicationDal = personelUseradvertApplicationDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(PersonelUserAdvertApplication personelUseradvertApplicationDTO)
        {
            IResult result = await BusinessRules.Run(IsNameExist(personelUseradvertApplicationDTO.AdvertId, personelUseradvertApplicationDTO.PersonelUserId));

            if (result != null)
            {
                return result;
            }
            await _personelUseradvertApplicationDal.AddAsync(personelUseradvertApplicationDTO);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Terminate(PersonelUserAdvertApplication personelUseradvertApplicationDTO)
        {
            await _personelUseradvertApplicationDal.Terminate(personelUseradvertApplicationDTO);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertApplication>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<PersonelUserAdvertApplication>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAdvertApplication>>(await _personelUseradvertApplicationDal.GetAll(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserAdvertApplication?>> GetById(string id)
        {

            return new SuccessDataResult<PersonelUserAdvertApplication?>(await _personelUseradvertApplicationDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertApplication>>> GetAllByCompanyId(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertApplication>>(await _personelUseradvertApplicationDal.GetAll(c => c.CompanyUserId == id), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertApplication>>> GetAllByPersonelId(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertApplication>>(await _personelUseradvertApplicationDal.GetAll(p => p.PersonelUserId == id), Messages.SuccessListed);
        }



        //DTO Methods

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertApplicationDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data != null)
            {
                return new ErrorDataResult<List<PersonelUserAdvertApplicationDTO>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAdvertApplicationDTO>>(await _personelUseradvertApplicationDal.GetAllDTO(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertApplicationDTO>>> GetAllByCompanyUserIdDTO(UserAdminDTO userAdminDTO)
        {
            return new SuccessDataResult<List<PersonelUserAdvertApplicationDTO>>(await _personelUseradvertApplicationDal.GetAllByCompanyUserIdDTO(userAdminDTO.Id), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertApplicationDTO>>> GetAllByPersonelUserIdDTO(UserAdminDTO userAdminDTO)
        {
            return new SuccessDataResult<List<PersonelUserAdvertApplicationDTO>>(await _personelUseradvertApplicationDal.GetAllByPersonelUserIdDTO(userAdminDTO.Id), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertApplicationDTO>>> GetAllByAdvertIdDTO(UserAdminDTO userAdminDTO)
        {
            return new SuccessDataResult<List<PersonelUserAdvertApplicationDTO>>(await _personelUseradvertApplicationDal.GetAllByAdvertIdDTO(userAdminDTO.Id), Messages.SuccessListed);
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string advertId, string personelUserId)
        {
            var result = await _personelUseradvertApplicationDal.GetAll(c => c.AdvertId == advertId && c.PersonelUserId == personelUserId);

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
