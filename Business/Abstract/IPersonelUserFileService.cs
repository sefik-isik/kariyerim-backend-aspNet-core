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
        Task<IResult> Add(PersonelUserFile personelUserFile);
        Task<IResult> Update(PersonelUserFile personelUserFile);
        Task<IResult> Delete(PersonelUserFile personelUserFile);
        Task<IResult> Terminate(PersonelUserFile personelUserFile);
        Task<IDataResult<List<PersonelUserFile>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserFile>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUserFile>> GetById(UserAdminDTO userAdminDTO);

        //DTO
        Task<IDataResult<List<PersonelUserFileDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserFileDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);

    }
}
