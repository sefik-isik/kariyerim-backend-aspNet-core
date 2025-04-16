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
    public class PersonelUserAddressManager : IPersonelUserAddressService
    {
        IPersonelUserAddressDal _personelUserAddressDal;
        IUserService _userService;

        public PersonelUserAddressManager(IPersonelUserAddressDal userAddressDal, IUserService userService)
        {
            _personelUserAddressDal = userAddressDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserAddress personelUserAddress)
        {
            _personelUserAddressDal.Add(personelUserAddress);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserAddress personelUserAddress)
        {
            _personelUserAddressDal.Update(personelUserAddress);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserAddress personelUserAddress)
        {
            _personelUserAddressDal.Delete(personelUserAddress);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAddress>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(_personelUserAddressDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(_personelUserAddressDal.GetAll());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserAddress> GetById(int personelUserAddressId)
        {
            return new SuccessDataResult<PersonelUserAddress>(_personelUserAddressDal.Get(u=>u.Id == personelUserAddressId));
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAddressDTO>> GetAllDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(_personelUserAddressDal.GetAllDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(_personelUserAddressDal.GetAllDTO(), Messages.CompaniesListed);
            }
            
        }

    }
}
