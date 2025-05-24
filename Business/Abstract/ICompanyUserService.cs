using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Business.Abstract
{
    public interface ICompanyUserService
    {
        IResult Add(CompanyUser companyUser);
        IResult Update(CompanyUser companyUser);
        IResult Delete(CompanyUser companyUser);
        IDataResult<List<CompanyUser>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUser>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<CompanyUser> GetByAdminId(UserAdminDTO userAdminDTO);
        IDataResult<CompanyUser> GetById(int id);

        //DTO
        IDataResult<List<CompanyUserDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
        
    }
}
