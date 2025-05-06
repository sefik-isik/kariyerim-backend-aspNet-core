using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Business.Abstract
{
    public interface ICompanyUserService
    {
        IResult Add(CompanyUser companyUser);
        IResult Update(CompanyUser companyUser);
        IResult Delete(CompanyUser companyUser);
        IDataResult<List<CompanyUser>> GetAll(int userId);IDataResult<List<CompanyUser>> GetDeletedAll(int userId);
        IDataResult<CompanyUser> GetById(int UserId);

        //DTO
        IDataResult<List<CompanyUserDTO>> GetAllDTO(int userId);
IDataResult<List<CompanyUserDTO>> GetAllDeletedDTO(int userId);
        
    }
}
