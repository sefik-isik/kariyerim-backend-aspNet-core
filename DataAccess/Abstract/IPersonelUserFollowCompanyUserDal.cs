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
    public interface IPersonelUserFollowCompanyUserDal : IEntityRepository<PersonelUserFollowCompanyUser>
    {

        Task<List<PersonelUserFollowCompanyUserDTO>> GetAllDTO();
        Task<List<PersonelUserFollowCompanyUserDTO>> GetAllByCompanyIdDTO(string id);
        Task<List<PersonelUserFollowCompanyUserDTO>> GetAllByPersonelIdDTO(string id);
    }
}
