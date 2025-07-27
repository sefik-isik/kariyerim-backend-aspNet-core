using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
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
            IResult result = BusinessRules.Run(IsNameExist(user.Email), IsTelephoneExist(user.PhoneNumber));

            if (result != null)
            {
                return result;
            }
            _userDal.AddAsync(user);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public IResult Update(User user)
        {
            User currentUser = GetById(user.Id);

            var newUser = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Status = currentUser.Status,
                Code = currentUser.Code,
                PasswordHash = currentUser.PasswordHash,
                PasswordSalt = currentUser.PasswordSalt,
                CreatedDate = currentUser.CreatedDate,
                UpdatedDate = currentUser.UpdatedDate,
                DeletedDate = currentUser.DeletedDate,

            };

            _userDal.UpdateAsync(newUser);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public IResult Delete(User user)
        {
            User currentUser = GetById(user.Id);

            var newUser = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Status = currentUser.Status,
                Code = currentUser.Code,
                PasswordHash = currentUser.PasswordHash,
                PasswordSalt = currentUser.PasswordSalt,
                CreatedDate = currentUser.CreatedDate,
                UpdatedDate = currentUser.UpdatedDate,
                DeletedDate = currentUser.DeletedDate,

            };

            _userDal.Delete(newUser);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(User user)
        {
            _userDal.TerminateSubDatas(user.Id);
            _userDal.Terminate(user);
            return new SuccessResult(Messages.SuccessTerminate);
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


        public User GetById(string id)
        {
                return _userDal.Get(u => u.Id == id);
        }

        //[SecuredOperation("admin,user")]
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
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllDTO().FindAll(c => c.Id == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UserDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = IsAdmin(userAdminDTO);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetDeletedAllDTO().FindAll(c => c.Id == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UserDTO>> GetAllCompanyUserDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllCompanyUserDTO().FindAll(c => c.Id == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllCompanyUserDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UserDTO>> GetAllPersonelUserDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllPersonelUserDTO().FindAll(c => c.Id == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllPersonelUserDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _userDal.GetAll(c => c.Email.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult IsTelephoneExist(string entityName)
        {
            var result = _userDal.GetAll(c => c.PhoneNumber == entityName).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
