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
    public interface IPersonelUserCoverLetterService
    {
        Task<IResult> Add(PersonelUserCoverLetter personelUserCoverLetter);
        Task<IResult> Update(PersonelUserCoverLetter personelUserCoverLetter);
        Task<IResult> Delete(PersonelUserCoverLetter personelUserCoverLetter);
        Task<IResult> Terminate(PersonelUserCoverLetter personelUserCoverLetter);
        Task<IDataResult<List<PersonelUserCoverLetter>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserCoverLetter>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUserCoverLetter>> GetById(UserAdminDTO userAdminDTO);

        //DTO
        Task<IDataResult<List<PersonelUserCoverLetterDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserCoverLetterDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);

    }
}
