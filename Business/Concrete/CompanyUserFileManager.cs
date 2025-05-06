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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyUserFileManager : ICompanyUserFileService
    {
        ICompanyUserFileDal _companyFileDal;
        IUserService _userService;

        public CompanyUserFileManager(ICompanyUserFileDal companyUserFileDal, IUserService userService)
        {
            _companyFileDal = companyUserFileDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(CompanyUserFile companyUserFile)
        {
            _companyFileDal.Add(companyUserFile);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(CompanyUserFile companyUserFile)
        {
            _companyFileDal.Update(companyUserFile);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserFile companyUserFile)
        {
            _companyFileDal.Delete(companyUserFile);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserFile>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserFile>>(_companyFileDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserFile>>(_companyFileDal.GetAll());
            }
        }

        [SecuredOperation("admin")]
        public IDataResult<List<CompanyUserFile>> GetDeletedAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserFile>>(_companyFileDal.GetDeletedAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserFile>>(_companyFileDal.GetDeletedAll());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUserFile> GetById(int companyFileId)
        {
            return new SuccessDataResult<CompanyUserFile>(_companyFileDal.Get(c=> c.Id == companyFileId));
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserFileDTO>> GetAllDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyFileDal.GetAllDTO().FindAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyFileDal.GetAllDTO());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserFileDTO>> GetAllDeletedDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyFileDal.GetAllDeletedDTO().FindAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyFileDal.GetAllDeletedDTO());
            }

        }

    }
}
