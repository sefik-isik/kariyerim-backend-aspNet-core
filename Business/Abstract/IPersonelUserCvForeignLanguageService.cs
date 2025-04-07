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
    public interface IPersonelUserCvForeignLanguageService
    {
        IResult Add(PersonelUserCvForeignLanguage cvForeignLanguage);
        IResult Update(PersonelUserCvForeignLanguage cvForeignLanguage);
        IResult Delete(PersonelUserCvForeignLanguage cvForeignLanguage);
        IDataResult<List<PersonelUserCvForeignLanguage>> GetAll(int UserId);
        IDataResult<PersonelUserCvForeignLanguage> GetById(int cvForeignLanguageId);

        //DTO
        IDataResult<List<PersonelUserCvForeignLanguageDTO>> GetCvForeignLanguageDTO(int userId);
        IDataResult<List<PersonelUserCvForeignLanguageDTO>> GetCvForeignLanguageDeletedDTO(int userId);
    }
}
