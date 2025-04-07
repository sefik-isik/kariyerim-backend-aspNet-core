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
        IResult Add(PersonelUserCvEducation cvEducation);
        IResult Update(PersonelUserCvEducation cvEducation);
        IResult Delete(PersonelUserCvEducation cvEducation);
        IDataResult<List<PersonelUserCvEducation>> GetAll(int UserId);
        IDataResult<PersonelUserCvEducation> GetById(int cvEducationId);

        //DTO
        IDataResult<List<PersonelUserCvEducationDTO>> GetCvEducationDTO(int userId);
        IDataResult<List<PersonelUserCvEducationDTO>> GetCvEducationDeletedDTO(int userId);
    }
}
