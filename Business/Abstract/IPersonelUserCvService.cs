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
    public interface IPersonelUserCvService
    {
        IResult Add(PersonelUserCv cv);
        IResult Update(PersonelUserCv cv);
        IResult Delete(PersonelUserCv cv);
        IDataResult<List<PersonelUserCv>> GetAll(int UserId);IDataResult<List<PersonelUserCv>> GetDeletedAll(int UserId);
        IDataResult<PersonelUserCv> GetById(int cvId);

        //DTO
        IDataResult<List<PersonelUserCvDTO>> GetAllDTO(int userId);IDataResult<List<PersonelUserCvDTO>> GetAllDeletedDTO(int userId);
    }
}
