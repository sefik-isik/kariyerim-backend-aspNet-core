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
        IResult Add(PersonelUserCvWorkExperience personelUserCvWorkExperience);
        IResult Update(PersonelUserCvWorkExperience personelUserCvWorkExperience);
        IResult Delete(PersonelUserCvWorkExperience personelUserCvWorkExperience);
        IResult Terminate(PersonelUserCvWorkExperience personelUserCvWorkExperience);
        IDataResult<List<PersonelUserCvWorkExperience>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserCvWorkExperience>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUserCvWorkExperience> GetById(UserAdminDTO userAdminDTO);

        //DTO
        IDataResult<List<PersonelUserCvWorkExperienceDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserCvWorkExperienceDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
