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
        Task<IResult> Add(PersonelUserImage personelUserImage);
        Task<IResult> Update(PersonelUserImage personelUserImage);
        Task<IResult> Delete(PersonelUserImage personelUserImage);
        Task<IResult> Terminate(PersonelUserImage personelUserImage);
        Task<IResult> DeleteImage(PersonelUserImage personelUserImage);
        Task<IDataResult<List<PersonelUserImage>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserImage>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUserImage>> GetById(UserAdminDTO userAdminDTO);
        Task<List<PersonelUserImage>> GetAllByPersonelUserId(string id);
        Task<IDataResult<List<PersonelUserImage>>> GetPersonelUserProfileImage(string id);


        //DTO
        Task<IDataResult<List<PersonelUserImageDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserImageDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);

    }
}
