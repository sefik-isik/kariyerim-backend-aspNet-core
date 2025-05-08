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
        IDataResult<List<PersonelUserFile>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserFile>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUserFile> GetById(int id);

        //DTO
        IDataResult<List<PersonelUserFileDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserFileDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO);

    }
}
