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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        [SecuredOperation("admin,user")]
        public IDataResult<UserDTO> GetByIdDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<UserDTO>(_userDal.GetByIdDTO(userAdminDTO.UserId, userAdminDTO.Id));
            }
            else
            {
                return new SuccessDataResult<UserDTO>(_userDal.GetByIdForAdminDTO(userAdminDTO.Id));
            }
        }

        [SecuredOperation("admin")]
        public User GetById(int id)
        {
                return _userDal.Get(u => u.Id == id);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UserCodeDTO>> GetCode(UserAdminDTO userAdminDTO)
        {
            return new SuccessDataResult<List<UserCodeDTO>>(_userDal.GetCode(userAdminDTO.UserId));
        }

        [SecuredOperation("admin,user")]
        public IDataResult<User> IsAdmin(UserAdminDTO userAdminDTO)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Status == UserStatus.Admin && userAdminDTO.Status == UserStatus.Admin && u.Id == userAdminDTO.UserId && u.Email == userAdminDTO.Email));
        }


        [SecuredOperation("admin,user")]
        public IDataResult<List<UserDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllDTO().FindAll(c => c.Id == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UserDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = IsAdmin(userAdminDTO);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllDeletedDTO().FindAll(c => c.Id == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllDeletedDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UserDTO>> GetAllCompanyUserDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllCompanyUserDTO().FindAll(c => c.Id == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllCompanyUserDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UserDTO>> GetAllPersonelUserDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllPersonelUserDTO().FindAll(c => c.Id == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllPersonelUserDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
        }
    }
}
