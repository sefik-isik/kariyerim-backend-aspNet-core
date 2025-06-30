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
        IResult Add(CompanyUserAdvertCity companyUserAdvertCity);
        IResult Update(CompanyUserAdvertCity companyUserAdvertCity);
        IResult Delete(CompanyUserAdvertCity companyUserAdvertCity);
        IResult Terminate(CompanyUserAdvertCity companyUserAdvertCity);
        IDataResult<List<CompanyUserAdvertCity>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserAdvertCity>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<CompanyUserAdvertCity> GetById(UserAdminDTO userAdminDTO);

        //DTO
        IDataResult<List<CompanyUserAdvertCityDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserAdvertCityDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
