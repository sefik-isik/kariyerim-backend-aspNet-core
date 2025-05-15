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
    public interface IPersonelUserImageService
    {
        IResult Add(PersonelUserImage personelUserImage);
        IResult Update(PersonelUserImage personelUserImage);
        IResult Delete(PersonelUserImage personelUserImage);
        IDataResult<List<PersonelUserImage>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserImage>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUserImage> GetById(UserAdminDTO userAdminDTO);

        //DTO
        IDataResult<List<PersonelUserImageDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserImageDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO);

    }
}
