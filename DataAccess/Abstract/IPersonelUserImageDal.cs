using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPersonelUserImageDal : IEntityRepository<PersonelUserImage>
    {
        Task<List<PersonelUserImageDTO>> GetAllDTO();
        Task<List<PersonelUserImageDTO>> GetDeletedAllDTO();
        Task UpdateProfilImage(string id);

        Task<List<PersonelUserImage>> GetPersonelUserProfileImage(string id);
    }
}
