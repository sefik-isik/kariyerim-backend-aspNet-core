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
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelUserAddressManager : IPersonelUserAddressService
    {
        IPersonelUserAddressDal _personelUserAddressDal;
        IUserService _userService;
        IPersonelUserService _personelUserService;

        public PersonelUserAddressManager(IPersonelUserAddressDal userAddressDal, IUserService userService, IPersonelUserService  personelUserService)
        {
            _personelUserAddressDal = userAddressDal;
            _userService = userService;
            _personelUserService = personelUserService;

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
        public IDataResult<List<PersonelUserAddress>> GetAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(_personelUserAddressDal.GetAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(_personelUserAddressDal.GetAll());
            }
            
        }
        [SecuredOperation("admin")]
        public IDataResult<List<PersonelUserAddress>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(_personelUserAddressDal.GetDeletedAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(_personelUserAddressDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserAddress> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserAddress>(_personelUserAddressDal.Get(c => c.Id == userAdminDTO.Id && c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<PersonelUserAddress>(_personelUserAddressDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAddressDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(_personelUserAddressDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(_personelUserAddressDal.GetAllDTO(), Messages.CompaniesListed);
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAddressDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(_personelUserAddressDal.GetAllDeletedDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(_personelUserAddressDal.GetAllDeletedDTO(), Messages.CompaniesListed);
            }

        }
    }
}
