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
    public interface IPersonelUserAdvertFollowDal : IEntityRepository<PersonelUserAdvertFollow>
    {
        Task<List<PersonelUserAdvertFollowDTO>> GetAllDTO();
        Task<List<PersonelUserAdvertFollowDTO>> GetAllByAdvertIdDTO(string id);
        Task<List<PersonelUserAdvertFollowDTO>> GetAllByPersonelIdDTO(string id);
    }
}
