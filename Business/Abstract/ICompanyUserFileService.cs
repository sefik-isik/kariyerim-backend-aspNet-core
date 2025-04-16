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
        IDataResult<List<CompanyUserFile>> GetAll(int UserId);
        IDataResult<CompanyUserFile> GetById(int companyUserFileId);
        

        //DTO
        IDataResult<List<CompanyUserFileDTO>> GetAllDTO(int userId);

    }
}
