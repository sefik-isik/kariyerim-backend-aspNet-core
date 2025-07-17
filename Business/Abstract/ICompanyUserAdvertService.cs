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

        IResult Add(CompanyUserAdvert companyUserAdvert);
        IResult Update(CompanyUserAdvert companyUserAdvert);
        IResult Delete(CompanyUserAdvert companyUserAdvert);
        IResult Terminate(CompanyUserAdvert companyUserAdvert);
        IDataResult<List<CompanyUserAdvert>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserAdvert>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<CompanyUserAdvert> GetById(UserAdminDTO userAdminDTO);

        IResult DeleteImage(CompanyUserAdvert companyUserAdvert);

        //DTO
        IDataResult<List<CompanyUserAdvertDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserAdvertDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
