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
        public IResult Add(CompanyUserDepartment companyUserDepartment)
        {
            _companyUserDepartmentDal.AddAsync(companyUserDepartment);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        public IResult Update(CompanyUserDepartment companyUserDepartment)
        {
            _companyUserDepartmentDal.UpdateAsync(companyUserDepartment);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserDepartment companyUserDepartment)
        {
            _companyUserDepartmentDal.Delete(companyUserDepartment);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public IResult Terminate(CompanyUserDepartment companyUserDepartment)
        {
            _companyUserDepartmentDal.Terminate(companyUserDepartment);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        //[SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDepartment>> GetAll()
        {
            return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetAll().ToList(), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDepartment>> GetDeletedAll()
        {
            return new SuccessDataResult<List<CompanyUserDepartment>>(_companyUserDepartmentDal.GetDeletedAll().ToList(), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUserDepartment> GetById(string id)
        {
            return new SuccessDataResult<CompanyUserDepartment>(_companyUserDepartmentDal.Get(c => c.Id == id));
        }
    }
}
