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

        public PersonelUserAddressManager(IPersonelUserAddressDal userAddressDal, IUserService userService)
        {
            _personelUserAddressDal = userAddressDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserAddress personelUserAddress)
        {
            if (_userService.GetById(personelUserAddress.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            IResult result = BusinessRules.Run(IsNameExist(personelUserAddress.AddressDetail));

            if (result != null)
            {
                return result;
            }
            _personelUserAddressDal.AddAsync(personelUserAddress);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserAddress personelUserAddress)
        {
            if (_userService.GetById(personelUserAddress.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserAddressDal.UpdateAsync(personelUserAddress);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserAddress personelUserAddress)
        {
            if (_userService.GetById(personelUserAddress.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserAddressDal.Delete(personelUserAddress);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(PersonelUserAddress personelUserAddress)
        {
            _personelUserAddressDal.Terminate(personelUserAddress);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAddress>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(_personelUserAddressDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(_personelUserAddressDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAddress>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(_personelUserAddressDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
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

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserAddress>(_personelUserAddressDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
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
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(_personelUserAddressDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(_personelUserAddressDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAddressDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(_personelUserAddressDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(_personelUserAddressDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _personelUserAddressDal.GetAll(c => c.AddressDetail.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
