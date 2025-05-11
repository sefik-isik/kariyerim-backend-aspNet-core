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
        IDataResult<List<PersonelUserCvEducation>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserCvEducation>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUserCvEducation> GetById(UserAdminDTO userAdminDTO);

        //DTO
        IDataResult<List<PersonelUserCvEducationDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserCvEducationDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO);
    }
}
