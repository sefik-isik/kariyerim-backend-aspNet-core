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
    public interface ICompanyUserFileService
    {
        Task<IResult> Add(CompanyUserFile companyUserFile);
        Task<IResult> Update(CompanyUserFile companyUserFile);
        Task<IResult> Delete(CompanyUserFile companyUserFile);
        Task<IResult> Terminate(CompanyUserFile companyUserFile);
        Task<IDataResult<List<CompanyUserFile>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserFile>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<CompanyUserFile>> GetById(UserAdminDTO userAdminDTO);

        //DTO
        Task<IDataResult<List<CompanyUserFileDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserFileDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
