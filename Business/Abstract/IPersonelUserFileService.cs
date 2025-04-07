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
    public interface IPersonelUserFileService
    {
        IResult Add(PersonelUserFile personelUserFile);
        IResult Update(PersonelUserFile personelUserFile);
        IResult Delete(PersonelUserFile personelUserFile);
        IDataResult<List<PersonelUserFile>> GetAll(int UserId);
        IDataResult<PersonelUserFile> GetById(int personelUserFileId);

        //DTO
        IDataResult<List<PersonelUserFileDTO>> GetPersonelUserFileDTO(int userId);
        IDataResult<List<PersonelUserFileDTO>> GetPersonelUserFileDeletedDTO(int userId);

    }
}
