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
    public interface ICompanyUserAddressService
    {
        Task<IResult> Add(CompanyUserAddress companyUserAddress);
        Task<IResult> Update(CompanyUserAddress companyUserAddress);
        Task<IResult> Delete(CompanyUserAddress companyUserAddress);
        Task<IResult> Terminate(CompanyUserAddress companyUserAddress);
        Task<IDataResult<List<CompanyUserAddress>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserAddress>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserAddress>>> GetAllByCompanyUserId(CompanyUser companyUser);
        Task<IDataResult<CompanyUserAddress>> GetById(UserAdminDTO userAdminDTO);

        //DTO
        Task<IDataResult<List<CompanyUserAddressDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserAddressDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
