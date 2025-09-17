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
        public async Task<IResult> Add(PersonelUserAddress personelUserAddress)
        {
            if (_userService.GetById(personelUserAddress.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            IResult result = await BusinessRules.Run(IsNameExist(personelUserAddress.AddressDetail));

            if (result != null)
            {
                return result;
            }
            await _personelUserAddressDal.AddAsync(personelUserAddress);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(PersonelUserAddress personelUserAddress)
        {
            if (_userService.GetById(personelUserAddress.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserAddressDal.UpdateAsync(personelUserAddress);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(PersonelUserAddress personelUserAddress)
        {
            if (_userService.GetById(personelUserAddress.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserAddressDal.Delete(personelUserAddress);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(PersonelUserAddress personelUserAddress)
        {
            await _personelUserAddressDal.Terminate(personelUserAddress);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAddress>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(await _personelUserAddressDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(await _personelUserAddressDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAddress>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(await _personelUserAddressDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddress>>(await _personelUserAddressDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserAddress?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserAddress?>(await _personelUserAddressDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserAddress?>(await _personelUserAddressDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAddressDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {

            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserAddressDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(alldto.ToList().FindAll(c => c.PersonelUserId == userAdminDTO.Id), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(alldto.ToList(), Messages.SuccessListed);
            }
            
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAddressDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserAddressDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAddressDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _personelUserAddressDal.GetAll(c => c.AddressDetail.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
