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
    public class CompanyUserDepartmentManager : ICompanyUserDepartmentService
    {
        ICompanyUserDepartmentDal _companyUserDepartmentDal;
        IUserService _userService;
        ICompanyUserService _companyUserService;

        public CompanyUserDepartmentManager(ICompanyUserDepartmentDal companyUserDepartmentDal, IUserService userService, ICompanyUserService companyUserService)
        {
            _companyUserDepartmentDal = companyUserDepartmentDal;
            _userService = userService;
            _companyUserService = companyUserService;

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
        public IDataResult<List<CompanyUserDepartment>> GetAll(UserAdminDTO userAdminDTO)
        {
            CompanyUser companyUser = (CompanyUser)_companyUserService.GetByUserId(userAdminDTO.UserId);
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetAll(c => c.CompanyUserId == companyUser.Id));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetAll());
            }
        }

        [SecuredOperation("admin")]
        public IDataResult<List<CompanyUserDepartment>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            CompanyUser companyUser = (CompanyUser)_companyUserService.GetByUserId(userAdminDTO.UserId);
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetDeletedAll(c => c.CompanyUserId == companyUser.Id));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetDeletedAll());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUserDepartment> GetById(int id)
        {
            return new SuccessDataResult<CompanyUserDepartment>(_companyUserDepartmentDal.Get(c=> c.Id == id));
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDepartmentDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetAllDTO());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDepartmentDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetAllDeletedDTO().FindAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetAllDeletedDTO());
            }

        }
    }
}
