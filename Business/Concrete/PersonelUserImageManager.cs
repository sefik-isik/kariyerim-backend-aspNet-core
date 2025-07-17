using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
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
        private readonly IWebHostEnvironment _environment;

        public PersonelUserImageManager(IPersonelUserImageDal personelUserImageDal, IUserService userService, IWebHostEnvironment environment)
        {
            _personelUserImageDal = personelUserImageDal;
            _userService = userService;
            _environment = environment;
        }

        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserImage personelUserImage)
        {
            if (_userService.GetById(personelUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserImageDal.AddAsync(personelUserImage);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserImage personelUserImage)
        {
            if (_userService.GetById(personelUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }

            if (personelUserImage.IsProfilImage == true)
            {
                _personelUserImageDal.UpdateProfilImage(personelUserImage.PersonelUserId);
            }

            _personelUserImageDal.UpdateAsync(personelUserImage);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserImage personelUserImage)
        {
            if (_userService.GetById(personelUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserImageDal.Delete(personelUserImage);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Terminate(PersonelUserImage personelUserImage)
        {
            DeleteImage(personelUserImage);
            _personelUserImageDal.Terminate(personelUserImage);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserImage>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserImage>>(_personelUserImageDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserImage>>(_personelUserImageDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserImage>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserImage>>(_personelUserImageDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
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

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserImage>(_personelUserImageDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
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

        public IResult DeleteImage(PersonelUserImage personelUserImage)
        {
            if (personelUserImage == null)
            {
                return new ErrorDataResult<PersonelUserImage>(Messages.ImageNotFound);
            }

            string fullImagePath = _environment.WebRootPath + "\\uploads\\images\\" + personelUserImage.UserId + "\\" + personelUserImage.ImageName;

            if (System.IO.File.Exists(fullImagePath))
            {
                System.IO.File.Delete(fullImagePath);
            }

            string fullThumbImagePath = _environment.WebRootPath + "\\uploads\\images\\" + personelUserImage.UserId + "\\thumbs\\" + personelUserImage.ImageName;

            if (System.IO.File.Exists(fullThumbImagePath))
            {
                System.IO.File.Delete(fullThumbImagePath);

            }

            personelUserImage.ImagePath = "https://localhost:7088/" + "/uploads/images/common/";
            personelUserImage.ImageName = "noImage.jpg";

            Update(personelUserImage);

            return new SuccessResult();
        }

    }
}
