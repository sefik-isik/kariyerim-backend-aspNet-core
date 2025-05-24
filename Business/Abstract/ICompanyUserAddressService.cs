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
        IResult Add(CompanyUserAddress companyUserAddress);
        IResult Update(CompanyUserAddress companyUserAddress);
        IResult Delete(CompanyUserAddress companyUserAddress);
        IDataResult<List<CompanyUserAddress>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserAddress>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<CompanyUserAddress> GetById(UserAdminDTO userAdminDTO);

        //DTO
        IDataResult<List<CompanyUserAddressDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserAddressDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
