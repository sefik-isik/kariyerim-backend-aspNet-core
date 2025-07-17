using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
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
    public class PersonelUserFollowCompanyUserManager : IPersonelUserFollowCompanyUserService
    {
        IPersonelUserFollowCompanyUserDal _personelUserFollowCompanyUserDal;
        IUserService _userService;
        ICompanyUserService _companyUserService;
        public PersonelUserFollowCompanyUserManager(IPersonelUserFollowCompanyUserDal personelUserFollowCompanyUserDal, IUserService userService, ICompanyUserService companyUserService)
        {
            _personelUserFollowCompanyUserDal = personelUserFollowCompanyUserDal;
            _userService = userService;
            _companyUserService = companyUserService;
        }

        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserFollowCompanyUser personelUserFollowCompanyUser)
        {
            IResult result = BusinessRules.Run(IsNameExist(personelUserFollowCompanyUser.CompanyUserId, personelUserFollowCompanyUser.PersonelUserId));

            if (result != null)
            {
                return result;
            }
            _personelUserFollowCompanyUserDal.AddAsync(personelUserFollowCompanyUser);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Terminate(PersonelUserFollowCompanyUser personelUserFollowCompanyUser)
        {
            _personelUserFollowCompanyUserDal.Terminate(personelUserFollowCompanyUser);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFollowCompanyUser>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<PersonelUserFollowCompanyUser>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFollowCompanyUser>>(_personelUserFollowCompanyUserDal.GetAll().OrderBy(s => s.Id).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserFollowCompanyUser> GetById(string id)
        {

            return new SuccessDataResult<PersonelUserFollowCompanyUser>(_personelUserFollowCompanyUserDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFollowCompanyUser>> GetAllByCompanyId(string id)
        {

            return new SuccessDataResult<List<PersonelUserFollowCompanyUser>>(_personelUserFollowCompanyUserDal.GetAll(c => c.CompanyUserId == id).OrderBy(s => s.CompanyUserId).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFollowCompanyUser>> GetAllByPersonelId(string id)
        {
            return new SuccessDataResult<List<PersonelUserFollowCompanyUser>>(_personelUserFollowCompanyUserDal.GetAll(p => p.PersonelUserId == id).OrderBy(s => s.PersonelUserId).ToList());
        }



        //DTO Methods

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFollowCompanyUserDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var user = _userService.GetById(userAdminDTO.UserId);

            if (userIsAdmin.Data == null && user.Code == UserCode.CompanyUser)
            {
                return new ErrorDataResult<List<PersonelUserFollowCompanyUserDTO>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFollowCompanyUserDTO>>(_personelUserFollowCompanyUserDal.GetAllDTO().OrderBy(s => s.Id).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFollowCompanyUserDTO>> GetAllByCompanyIdDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFollowCompanyUserDTO>>(_personelUserFollowCompanyUserDal.GetAllByCompanyIdDTO(userAdminDTO.Id).OrderBy(s => s.CompanyUserId).ToList());
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFollowCompanyUserDTO>>(_personelUserFollowCompanyUserDal.GetAllDTO().OrderBy(s => s.CompanyUserId).ToList());
            }

            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserFollowCompanyUserDTO>> GetAllByPersonelIdDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserFollowCompanyUserDTO>>(_personelUserFollowCompanyUserDal.GetAllByPersonelIdDTO(userAdminDTO.Id).OrderBy(s => s.PersonelUserId).ToList());
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFollowCompanyUserDTO>>(_personelUserFollowCompanyUserDal.GetAllDTO().OrderBy(s => s.CompanyUserId).ToList());
            }

            
        }

        //Business Rules
        private IResult IsNameExist(string companyUserId, string personelUserId)
        {
            var result = _personelUserFollowCompanyUserDal.GetAll(c => c.CompanyUserId == companyUserId && c.PersonelUserId == personelUserId).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
