using Core.Entities.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyUserService
    {
        Task<IResult> Add(CompanyUser companyUser);
        Task<IResult> Update(CompanyUser companyUser);
        Task<IResult> Delete(CompanyUser companyUser);
        Task<IResult> Terminate(CompanyUser companyUser);
        Task<IDataResult<List<CompanyUser>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUser>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserDTO>>> GetAllForAllUserDTO();
        Task<IDataResult<CompanyUser>> GetByAdminId(UserAdminDTO userAdminDTO);
        Task<IDataResult<CompanyUser>> GetById(string id);
        
        Task<IDataResult<CompanyUserPageModel>> GetAllByPage(CompanyUserPageModel pageModel);

        //DTO
        Task<IDataResult<List<CompanyUserDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
        
    }
}
