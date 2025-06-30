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
        IResult Add(PersonelUserCoverLetter personelUserCoverLetter);
        IResult Update(PersonelUserCoverLetter personelUserCoverLetter);
        IResult Delete(PersonelUserCoverLetter personelUserCoverLetter);
        IResult Terminate(PersonelUserCoverLetter personelUserCoverLetter);
        IDataResult<List<PersonelUserCoverLetter>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserCoverLetter>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUserCoverLetter> GetById(UserAdminDTO userAdminDTO);

        //DTO
        IDataResult<List<PersonelUserCoverLetterDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserCoverLetterDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);

    }
}
