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
        Task<IResult> Add(PersonelUserCv personelUserCv);
        Task<IResult> Update(PersonelUserCv personelUserCv);
        Task<IResult> Delete(PersonelUserCv personelUserCv);
        Task<IResult> Terminate(PersonelUserCv personelUserCv);
        Task<IDataResult<List<PersonelUserCv>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserCv>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUserCv>> GetById(UserAdminDTO userAdminDTO);
        Task<PersonelUserCv> GetPersonelUserCv(string id);

        //DTO
        Task<IDataResult<List<PersonelUserCvDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserCvDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
