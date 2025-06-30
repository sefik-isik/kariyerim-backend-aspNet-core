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
        IResult Terminate(CompanyUserImage companyUserImage);
        IDataResult<List<CompanyUserImage>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserImage>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<CompanyUserImage> GetById(UserAdminDTO userAdminDTO);
        IResult DeleteImage(CompanyUserImage companyUserImage);


        //DTO
        IDataResult<List<CompanyUserImageDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyUserImageDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
