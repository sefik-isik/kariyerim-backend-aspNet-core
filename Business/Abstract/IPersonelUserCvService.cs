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
        IResult Add(PersonelUserCv cv);
        IResult Update(PersonelUserCv cv);
        IResult Delete(PersonelUserCv cv);
        IDataResult<List<PersonelUserCv>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserCv>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUserCv> GetById(UserAdminDTO userAdminDTO);
        PersonelUserCv GetPersonelUserCv(int id);

        //DTO
        IDataResult<List<PersonelUserCvDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserCvDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
