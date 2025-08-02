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
    public interface IPersonelUserCvEducationService
    {
        Task<IResult> Add(PersonelUserCvEducation personelUserCvEducation);
        Task<IResult> Update(PersonelUserCvEducation personelUserCvEducation);
        Task<IResult> Delete(PersonelUserCvEducation personelUserCvEducation);
        Task<IResult> Terminate(PersonelUserCvEducation personelUserCvEducation);
        Task<IDataResult<List<PersonelUserCvEducation>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserCvEducation>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUserCvEducation>> GetById(UserAdminDTO userAdminDTO);

        //DTO
        Task<IDataResult<List<PersonelUserCvEducationDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserCvEducationDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
