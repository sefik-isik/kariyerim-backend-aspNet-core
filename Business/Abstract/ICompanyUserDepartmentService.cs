using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyUserDepartmentService
    {
        Task<IResult> Add(CompanyUserDepartment companyUserDepartment);
        Task<IResult> Update(CompanyUserDepartment companyUserDepartment);
        Task<IResult> Delete(CompanyUserDepartment companyUserDepartment);
        Task<IResult> Terminate(CompanyUserDepartment companyUserDepartment);
        Task<IDataResult<List<CompanyUserDepartment>>> GetAll();
        Task<IDataResult<List<CompanyUserDepartment>>> GetDeletedAll();
        Task<IDataResult<CompanyUserDepartment>> GetById(string id);
    }
}
