using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class PersonelUserImageManager : IPersonelUserImageService
    {
        IPersonelUserImageDal _personelUserImageDal;
        IUserService _userService;
        IPersonelUserService _personelUserService;

        public PersonelUserImageManager(IPersonelUserImageDal personelUserImageDal, IUserService userService, IPersonelUserService personelUserService)
        {
            _personelUserImageDal = personelUserImageDal;
            _userService = userService;
            _personelUserService = personelUserService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserImage personelUserImage)
        {
            _personelUserImageDal.Add(personelUserImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserImage personelUserImage)
        {
            _personelUserImageDal.Update(personelUserImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserImage personelUserImage)
        {
            _personelUserImageDal.Delete(personelUserImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserImage>> GetAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserImage>>(_personelUserImageDal.GetAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserImage>>(_personelUserImageDal.GetAll());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserImage>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserImage>>(_personelUserImageDal.GetDeletedAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserImage>>(_personelUserImageDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserImage> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserImage>(_personelUserImageDal.Get(c => c.Id == userAdminDTO.Id && c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<PersonelUserImage>(_personelUserImageDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserImageDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserImageDTO>>(_personelUserImageDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList());
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserImageDTO>>(_personelUserImageDal.GetAllDTO().OrderBy(s => s.Email).ToList());
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserImageDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserImageDTO>>(_personelUserImageDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList());
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserImageDTO>>(_personelUserImageDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList());
            }

        }

    }
}
