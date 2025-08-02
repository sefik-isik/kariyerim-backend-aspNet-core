using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyUserAdvertManager : ICompanyUserAdvertService
    {
        ICompanyUserAdvertDal _companyUserAdvertDal;
        IUserService _userService;
        private readonly IWebHostEnvironment _environment;

        public CompanyUserAdvertManager(ICompanyUserAdvertDal companyUserAdvertDal, IUserService userService, IWebHostEnvironment environment)
        {
            _companyUserAdvertDal = companyUserAdvertDal;
            _userService = userService;
            _environment = environment;
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(CompanyUserAdvert companyUserAdvert)
        {
            if (_userService.GetById(companyUserAdvert.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            IResult result = await BusinessRules.Run(IsNameExist(companyUserAdvert.AdvertName));

            if (result != null)
            {
                return result;
            }
            await _companyUserAdvertDal.AddAsync(companyUserAdvert);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(CompanyUserAdvert companyUserAdvert)
        {
            if (_userService.GetById(companyUserAdvert.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserAdvertDal.UpdateAsync(companyUserAdvert);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(CompanyUserAdvert companyUserAdvert)
        {
            if (_userService.GetById(companyUserAdvert.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserAdvertDal.Delete(companyUserAdvert);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Terminate(CompanyUserAdvert companyUserAdvert)
        {
            await DeleteImage(companyUserAdvert);
            await _companyUserAdvertDal.TerminateSubDatas(companyUserAdvert.Id);
            await _companyUserAdvertDal.Terminate(companyUserAdvert);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvert>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvert>>(await _companyUserAdvertDal.GetAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvert>>(await _companyUserAdvertDal.GetAll(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvert>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvert>>(await _companyUserAdvertDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvert>>(await _companyUserAdvertDal.GetDeletedAll(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUserAdvert?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserAdvert?>(await _companyUserAdvertDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<CompanyUserAdvert?>(await _companyUserAdvertDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var user = await _userService.GetById(userAdminDTO.UserId);
            var allDtos = await _companyUserAdvertDal.GetAllDTO();

            if (userIsAdmin.Data == null && user.Code == UserCode.CompanyUser)
            {
                return new SuccessDataResult<List<CompanyUserAdvertDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var user = await _userService.GetById(userAdminDTO.UserId);
            var allDtos = await _companyUserAdvertDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null && user.Code == UserCode.CompanyUser)
            {
                return new SuccessDataResult<List<CompanyUserAdvertDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }

        }

        public async Task<IResult> DeleteImage(CompanyUserAdvert companyUserAdvert)
        {
            if (companyUserAdvert == null)
            {
                return new ErrorDataResult<CompanyUserAdvert>(Messages.ImageNotFound);
            }

            string fullImagePath =  _environment.WebRootPath + "\\uploads\\images\\" + companyUserAdvert.UserId + "\\" + companyUserAdvert.AdvertImageName;

            if (System.IO.File.Exists(fullImagePath))
            {
                System.IO.File.Delete(fullImagePath);
            }

            string fullThumbImagePath =  _environment.WebRootPath + "\\uploads\\images\\" + companyUserAdvert.UserId + "\\thumbs\\" + companyUserAdvert.AdvertImageName;

            if (System.IO.File.Exists(fullThumbImagePath))
            {
                System.IO.File.Delete(fullThumbImagePath);

            }

            companyUserAdvert.AdvertImagePath = "https://localhost:7088/" + "/uploads/images/common/";
            companyUserAdvert.AdvertImageName = "noImage.jpg";

            await Update(companyUserAdvert);

            return new SuccessResult();
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _companyUserAdvertDal.GetAll(c => c.AdvertName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
