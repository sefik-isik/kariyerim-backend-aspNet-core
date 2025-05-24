using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
        ICompanyUserService _companyUserService;

        public CompanyUserFileManager(ICompanyUserFileDal companyUserFileDal, IUserService userService, ICompanyUserService companyUserService)
        {
            _companyUserFileDal = companyUserFileDal;
            _userService = userService;
            _companyUserService = companyUserService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(CompanyUserFile companyUserFile)
        {
            _companyUserFileDal.Add(companyUserFile);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(CompanyUserFile companyUserFile)
        {
            _companyUserFileDal.Update(companyUserFile);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserFile companyUserFile)
        {
            _companyUserFileDal.Delete(companyUserFile);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserFile>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var companyUser = _companyUserService.GetByAdminId(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserFile>>(_companyUserFileDal.GetAll(c => c.CompanyUserId == companyUser.Data.Id));
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

            var companyUser = _companyUserService.GetByAdminId(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserFile>>(_companyUserFileDal.GetDeletedAll(c => c.CompanyUserId == companyUser.Data.Id));
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

            var companyUser = _companyUserService.GetByAdminId(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserFile>(_companyUserFileDal.Get(c => c.Id == userAdminDTO.Id && c.CompanyUserId == companyUser.Data.Id));
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
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyUserFileDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyUserFileDal.GetAllDTO().OrderBy(s => s.Email).ToList());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserFileDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyUserFileDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserFileDTO>>(_companyUserFileDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList());
            }

        }

    }
}
