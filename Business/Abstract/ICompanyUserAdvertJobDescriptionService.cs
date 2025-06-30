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
    public interface ICompanyUserAdvertJobDescriptionService
    {
        IResult Add(CompanyUserAdvertJobDescription companyUserAdvertJobDescription);
        IResult Update(CompanyUserAdvertJobDescription companyUserAdvertJobDescription);
        IResult Delete(CompanyUserAdvertJobDescription companyUserAdvertJobDescription);
        IResult Terminate(CompanyUserAdvertJobDescription companyUserAdvertJobDescription);
        IDataResult<List<CompanyUserAdvertJobDescription>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserAdvertJobDescription>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<CompanyUserAdvertJobDescription> GetById(UserAdminDTO userAdminDTO);

        //DTO
        IDataResult<List<CompanyUserAdvertJobDescriptionDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserAdvertJobDescriptionDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
