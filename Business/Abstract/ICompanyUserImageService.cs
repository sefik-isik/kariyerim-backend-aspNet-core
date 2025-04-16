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
        IDataResult<List<CompanyUserImage>> GetAll(int UserId);
        IDataResult<CompanyUserImage> GetById(int companyUserImageId);
        

        //DTO
        IDataResult<List<CompanyUserImageDTO>> GetAllDTO(int userId);

    }
}
