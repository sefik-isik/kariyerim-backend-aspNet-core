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
    public interface ICompanyUserImageService
    {
        Task<IResult> Add(CompanyUserImage companyUserImage);
        Task<IResult> Update(CompanyUserImage companyUserImage);
        Task<IResult> Delete(CompanyUserImage companyUserImage);
        Task<IResult> Terminate(CompanyUserImage companyUserImage);
        Task<IResult> DeleteImage(CompanyUserImage companyUserImage);
        Task<IDataResult<List<CompanyUserImage>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserImage>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<CompanyUserImage>> GetById(UserAdminDTO userAdminDTO);



        //DTO
        Task<IDataResult<List<CompanyUserImageDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserImageDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
