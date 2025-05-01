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
        //[SecuredOperation("admin")]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
        //[SecuredOperation("admin,user")]
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

        //[SecuredOperation("admin,user")]
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        [SecuredOperation("admin")]
        public User GetById(int userId)
        {
            return _userDal.Get(u => u.Id == userId);
        }

        [SecuredOperation("admin")]
        public IDataResult<UserDTO> GetByIdDTO(int userId)
        {
            return new SuccessDataResult<UserDTO>(_userDal.GetByIdDTO(userId));
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UserCodeDTO>> GetCode(int userId)
        {
            return new SuccessDataResult<List<UserCodeDTO>>(_userDal.GetCode(userId));
        }

        [SecuredOperation("admin")]
        public IDataResult<User> IsAdmin(string status, int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Status == status && u.Id == userId));
        }
        [SecuredOperation("admin")]
        public IDataResult<List<UserDTO>> GetAllDTO(int userId)
        {
            var userIsAdmin = IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllDTO().FindAll(c => c.Id == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllDTO(), Messages.CompaniesListed);
            }
        }
    }
}
