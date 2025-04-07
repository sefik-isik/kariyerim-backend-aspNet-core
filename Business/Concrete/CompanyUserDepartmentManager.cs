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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyUserDepartmentManager : ICompanyUserDepartmentService
    {
        ICompanyUserDepartmentDal _companyUserDepartmentDal;
        IUserService _userService;

        public CompanyUserDepartmentManager(ICompanyUserDepartmentDal companyUserDepartmentDal, IUserService userService)
        {
            _companyUserDepartmentDal = companyUserDepartmentDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(CompanyUserDepartment companyUserDepartment)
        {
            _companyUserDepartmentDal.Add(companyUserDepartment);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(CompanyUserDepartment companyUserDepartment)
        {
            _companyUserDepartmentDal.Update(companyUserDepartment);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserDepartment companyUserDepartment)
        {
            _companyUserDepartmentDal.Delete(companyUserDepartment);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDepartment>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetAll());
            }
        }
        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUserDepartment> GetById(int companyUserDepartmentId)
        {
            return new SuccessDataResult<CompanyUserDepartment>(_companyUserDepartmentDal.Get(c=> c.Id == companyUserDepartmentId));
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDepartmentDTO>> GetCompanyUserDepartmentDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetCompanyUserDepartmentDTO().FindAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetCompanyUserDepartmentDTO());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDepartmentDTO>> GetCompanyUserDepartmentDeletedDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetCompanyUserDepartmentDTO().FindAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetCompanyUserDepartmentDTO());
            }
            
        }
    }
}
