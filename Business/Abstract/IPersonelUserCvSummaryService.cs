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
    public interface IPersonelUserCvSummaryService
    {
        Task<IResult> Add(PersonelUserCvSummary personelUserCvSummary);
        Task<IResult> Update(PersonelUserCvSummary personelUserCvSummary);
        Task<IResult> Delete(PersonelUserCvSummary personelUserCvSummary);
        Task<IResult> Terminate(PersonelUserCvSummary personelUserCvSummary);
        Task<IDataResult<List<PersonelUserCvSummary>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserCvSummary>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUserCvSummary>> GetById(UserAdminDTO userAdminDTO);

        //DTO
        Task<IDataResult<List<PersonelUserCvSummaryDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserCvSummaryDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);

    }
}
