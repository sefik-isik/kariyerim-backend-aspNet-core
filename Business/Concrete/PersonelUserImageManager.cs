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
        public async Task<IResult> Add(PersonelUserImage personelUserImage)
        {
            if (_userService.GetById(personelUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserImageDal.AddAsync(personelUserImage);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(PersonelUserImage personelUserImage)
        {
            if (_userService.GetById(personelUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }

            if (personelUserImage.IsProfilImage == true)
            {
                await _personelUserImageDal.UpdateProfilImage(personelUserImage.PersonelUserId);
            }

            await _personelUserImageDal.UpdateAsync(personelUserImage);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(PersonelUserImage personelUserImage)
        {
            if (_userService.GetById(personelUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserImageDal.Delete(personelUserImage);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(PersonelUserImage personelUserImage)
        {
            await DeleteImage(personelUserImage);
            await _personelUserImageDal.Terminate(personelUserImage);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserImage>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserImage>>(await _personelUserImageDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserImage>>(await _personelUserImageDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserImage>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserImage>>(await _personelUserImageDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserImage>>(await _personelUserImageDal.GetDeletedAll());
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<List<PersonelUserImage>> GetAllByPersonelUserId(string id)
        {
            return await _personelUserImageDal.GetAll(data => data.PersonelUserId == id);

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserImage?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserImage?>(await _personelUserImageDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserImage?>(await _personelUserImageDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserImage>>> GetPersonelUserProfileImage(string id)
        {
            return new SuccessDataResult<List<PersonelUserImage>>(await _personelUserImageDal.GetPersonelUserProfileImage(id));
        }

        //DTO
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserImageDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var allDtos = await _personelUserImageDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserImageDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserImageDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserImageDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var allDtos = await _personelUserImageDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserImageDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserImageDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        public async Task<IResult> DeleteImage(PersonelUserImage personelUserImage)
        {
            if (personelUserImage == null)
            {
                return new ErrorDataResult<PersonelUserImage>(Messages.ImageNotFound);
            }

            string ImagePath = _environment.WebRootPath + "\\uploads\\images\\" + personelUserImage.UserId;
            string FullImagePath = ImagePath + "\\" + personelUserImage.ImageName;

            string ThumbImagePath = ImagePath + "\\thumbs\\";
            string FullThumbImagePath = ThumbImagePath + personelUserImage.ImageName;

            if (System.IO.File.Exists(FullImagePath))
            {
                System.IO.File.Delete(FullImagePath);
            }

            if (System.IO.File.Exists(FullThumbImagePath))
            {
                System.IO.File.Delete(FullThumbImagePath);
            }

            if (System.IO.Directory.Exists(ImagePath))
            {
                DirectoryInfo source = new DirectoryInfo(ImagePath);
                FileInfo[] sourceFiles = source.GetFiles();

                if (sourceFiles.Length == 0)
                {
                    System.IO.Directory.Delete(ImagePath, true);
                }
            }

            personelUserImage.ImagePath = "https://localhost:7088/" + "/uploads/images/common/";
            personelUserImage.ImageName = "noImage.jpg";

           await Update(personelUserImage);

            return new SuccessResult();
        }

    }
}
