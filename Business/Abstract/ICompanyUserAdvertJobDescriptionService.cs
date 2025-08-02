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
    public interface ICompanyUserAdvertJobDescriptionService
    {
        Task<IResult> Add(CompanyUserAdvertJobDescription companyUserAdvertJobDescription);
        Task<IResult> Update(CompanyUserAdvertJobDescription companyUserAdvertJobDescription);
        Task<IResult> Delete(CompanyUserAdvertJobDescription companyUserAdvertJobDescription);
        Task<IResult> Terminate(CompanyUserAdvertJobDescription companyUserAdvertJobDescription);
        Task<IDataResult<List<CompanyUserAdvertJobDescription>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserAdvertJobDescription>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<CompanyUserAdvertJobDescription>> GetById(UserAdminDTO userAdminDTO);

        //DTO
        Task<IDataResult<List<CompanyUserAdvertJobDescriptionDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserAdvertJobDescriptionDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
