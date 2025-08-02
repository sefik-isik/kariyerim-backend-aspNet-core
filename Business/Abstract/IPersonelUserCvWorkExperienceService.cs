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
    public interface IPersonelUserCvWorkExperienceService
    {
        Task<IResult> Add(PersonelUserCvWorkExperience personelUserCvWorkExperience);
        Task<IResult> Update(PersonelUserCvWorkExperience personelUserCvWorkExperience);
        Task<IResult> Delete(PersonelUserCvWorkExperience personelUserCvWorkExperience);
        Task<IResult> Terminate(PersonelUserCvWorkExperience personelUserCvWorkExperience);
        Task<IDataResult<List<PersonelUserCvWorkExperience>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserCvWorkExperience>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUserCvWorkExperience>> GetById(UserAdminDTO userAdminDTO);

        //DTO
        Task<IDataResult<List<PersonelUserCvWorkExperienceDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserCvWorkExperienceDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
