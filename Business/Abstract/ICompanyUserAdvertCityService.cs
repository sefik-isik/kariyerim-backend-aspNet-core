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
    public interface ICompanyUserAdvertCityService
    {
        Task<IResult> Add(CompanyUserAdvertCity companyUserAdvertCity);
        Task<IResult> Update(CompanyUserAdvertCity companyUserAdvertCity);
        Task<IResult> Delete(CompanyUserAdvertCity companyUserAdvertCity);
        Task<IResult> Terminate(CompanyUserAdvertCity companyUserAdvertCity);
        Task<IDataResult<List<CompanyUserAdvertCity>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserAdvertCity>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<CompanyUserAdvertCity>> GetById(UserAdminDTO userAdminDTO);

        //DTO
        Task<IDataResult<List<CompanyUserAdvertCityDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<CompanyUserAdvertCityDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
