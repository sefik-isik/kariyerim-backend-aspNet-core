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

        public CompanyUserDepartmentManager(ICompanyUserDepartmentDal companyUserDepartmentDal)
        {
            _companyUserDepartmentDal = companyUserDepartmentDal;

        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(CompanyUserDepartment companyUserDepartment)
        {
            await _companyUserDepartmentDal.AddAsync(companyUserDepartment);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(CompanyUserDepartment companyUserDepartment)
        {
            await _companyUserDepartmentDal.UpdateAsync(companyUserDepartment);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(CompanyUserDepartment companyUserDepartment)
        {
            await _companyUserDepartmentDal.Delete(companyUserDepartment);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(CompanyUserDepartment companyUserDepartment)
        {
            await _companyUserDepartmentDal.Terminate(companyUserDepartment);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserDepartment>>> GetAll()
        {
            var result = await _companyUserDepartmentDal.GetAll();
            result = result.OrderBy(x => x.DepartmentName).ToList();
            return new SuccessDataResult<List<CompanyUserDepartment>>(await _companyUserDepartmentDal.GetAll(), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserDepartment>>> GetDeletedAll()
        {
            var result = await _companyUserDepartmentDal.GetDeletedAll();
            result = result.OrderBy(x => x.DepartmentName).ToList();
            return new SuccessDataResult<List<CompanyUserDepartment>>(await _companyUserDepartmentDal.GetDeletedAll(), Messages.SuccessListed);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUserDepartment?>> GetById(string id)
        {
            return new SuccessDataResult<CompanyUserDepartment?>(await _companyUserDepartmentDal.Get(c => c.Id == id));
        }
    }
}
