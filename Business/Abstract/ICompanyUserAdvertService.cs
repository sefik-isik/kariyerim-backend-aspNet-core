using Core.Entities.Concrete;
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
    public interface ICompanyUserAdvertService
    {

        Task<IResult> Add(CompanyUserAdvert companyUserAdvert);
        Task<IResult> Update(CompanyUserAdvert companyUserAdvert);
        Task<IResult> Delete(CompanyUserAdvert companyUserAdvert);
        Task<IResult> Terminate(CompanyUserAdvert companyUserAdvert);
        Task<IResult> DeleteImage(CompanyUserAdvert companyUserAdvert);
        Task<IDataResult<List<CompanyUserAdvert>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserAdvert>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<CompanyUserAdvert>> GetById(UserAdminDTO userAdminDTO);



        //DTO
        Task<IDataResult<List<CompanyUserAdvertDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserAdvertDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
