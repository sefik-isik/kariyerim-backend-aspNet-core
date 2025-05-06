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
        IDataResult<List<CompanyUserAddress>> GetAll(int UserId);IDataResult<List<CompanyUserAddress>> GetDeletedAll(int UserId);
        IDataResult<CompanyUserAddress> GetById(int companyUserAddressId);
        


        //DTO
        IDataResult<List<CompanyUserAddressDTO>> GetAllDTO(int userId);
IDataResult<List<CompanyUserAddressDTO>> GetAllDeletedDTO(int userId);
    }
}
