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
        IResult Add(PersonelUserCvWorkExperience cvWorkExperience);
        IResult Update(PersonelUserCvWorkExperience cvWorkExperience);
        IResult Delete(PersonelUserCvWorkExperience cvWorkExperience);
        IDataResult<List<PersonelUserCvWorkExperience>> GetAll(int UserId);
        IDataResult<PersonelUserCvWorkExperience> GetById(int cvWorkExperienceId);
        
        IDataResult<List<PersonelUserCvWorkExperienceDTO>> GetAllDTO(int userId);
    }
}
