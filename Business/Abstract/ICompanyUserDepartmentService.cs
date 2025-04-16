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
        IResult Add(CompanyUserDepartment companyUserDepartment);
        IResult Update(CompanyUserDepartment companyUserDepartment);
        IResult Delete(CompanyUserDepartment companyUserDepartment);
        IDataResult<List<CompanyUserDepartment>> GetAll(int UserId);
        IDataResult<CompanyUserDepartment> GetById(int companyUserDepartmentId);
        

        //DTO
        IDataResult<List<CompanyUserDepartmentDTO>> GetAllDTO(int userId);

    }
}
