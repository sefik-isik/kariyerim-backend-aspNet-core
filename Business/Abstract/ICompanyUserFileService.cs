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
    public interface ICompanyUserFileService
    {
        IResult Add(CompanyUserFile companyUserFile);
        IResult Update(CompanyUserFile companyUserFile);
        IResult Delete(CompanyUserFile companyUserFile);
        IDataResult<List<CompanyUserFile>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserFile>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<CompanyUserFile> GetById(UserAdminDTO userAdminDTO);

        //DTO
        IDataResult<List<CompanyUserFileDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserFileDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
