using Core.Entities.Concrete;
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
    public interface ICompanyUserAdvertService
    {

        Task<IResult> Add(CompanyUserAdvert companyUserAdvert);
        Task<IResult> Update(CompanyUserAdvert companyUserAdvert);
        Task<IResult> Delete(CompanyUserAdvert companyUserAdvert);
        Task<IResult> Terminate(CompanyUserAdvert companyUserAdvert);
        Task<IDataResult<List<CompanyUserAdvert>>> GetAll();
        Task<IDataResult<List<CompanyUserAdvert>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<CompanyUserAdvertPageModel>> GetAllByPage(CompanyUserAdvertPageModel companyUserAdvertPageModel);
        Task<List<CompanyUserAdvert>> GetAllByCompanyUserId(CompanyUser companyUser);
        Task<IDataResult<CompanyUserAdvert>> GetById(string id);



        //DTO
        Task<IDataResult<List<CompanyUserAdvertDTO>>> GetAllDTO();
        Task<IDataResult<List<CompanyUserAdvertDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
