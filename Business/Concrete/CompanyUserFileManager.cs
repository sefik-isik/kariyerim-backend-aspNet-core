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
    public class CompanyUserFileManager : ICompanyUserFileService
    {
        ICompanyUserFileDal _companyUserFileDal;
        IUserService _userService;

        public CompanyUserFileManager(ICompanyUserFileDal companyUserFileDal, IUserService userService)
        {
            _companyUserFileDal = companyUserFileDal;
            _userService = userService;
        }
        [SecuredOperation("admin,user")]
        public IResult Add(CompanyUserFile companyUserFile)
        {
            if (_userService.GetById(companyUserFile.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserFileDal.AddAsync(companyUserFile);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        public IResult Update(CompanyUserFile companyUserFile)
        {
            if (_userService.GetById(companyUserFile.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserFileDal.UpdateAsync(companyUserFile);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserFile companyUserFile)
        {
            if (_userService.GetById(companyUserFile.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserFileDal.Delete(companyUserFile);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public IResult Terminate(CompanyUserFile companyUserFile)
        {
            _companyUserFileDal.Terminate(companyUserFile);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserFile>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserFile>>(_companyUserFileDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserFile>>(_companyUserFileDal.GetAll());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserFile>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserFile>>(_companyUserFileDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserFile>>(_companyUserFileDal.GetDeletedAll());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUserFile> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserFile>(_companyUserFileDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<CompanyUserFile>(_companyUserFileDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserFileDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyUserFileDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyUserFileDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserFileDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyUserFileDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyUserFileDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }

    }
}
