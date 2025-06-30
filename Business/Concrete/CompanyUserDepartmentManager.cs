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
            if (_userService.GetById(companyUserDepartment.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserDepartmentDal.AddAsync(companyUserDepartment);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(CompanyUserDepartment companyUserDepartment)
        {
            if (_userService.GetById(companyUserDepartment.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserDepartmentDal.UpdateAsync(companyUserDepartment);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserDepartment companyUserDepartment)
        {
            if (_userService.GetById(companyUserDepartment.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserDepartmentDal.Delete(companyUserDepartment);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Terminate(CompanyUserDepartment companyUserDepartment)
        {
            _companyUserDepartmentDal.Terminate(companyUserDepartment);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDepartment>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.DepartmentName).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetAll().OrderBy(s => s.DepartmentName).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDepartment>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.DepartmentName).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetDeletedAll().OrderBy(s => s.DepartmentName).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUserDepartment> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserDepartment>(_companyUserDepartmentDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<CompanyUserDepartment>(_companyUserDepartmentDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDepartmentDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetAllDTO().OrderBy(s => s.Email).ToList());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDepartmentDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDepartmentDTO>>(_companyUserDepartmentDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList());
            }

        }
    }
}
