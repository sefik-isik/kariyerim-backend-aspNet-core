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
        IResult Add(CompanyUserImage companyUserImage);
        IResult Update(CompanyUserImage companyUserImage);
        IResult Delete(CompanyUserImage companyUserImage);
        IDataResult<List<CompanyUserImage>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserImage>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<CompanyUserImage> GetById(int id);
        

        //DTO
        IDataResult<List<CompanyUserImageDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserImageDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO);
    }
}
