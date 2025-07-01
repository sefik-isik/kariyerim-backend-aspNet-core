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
        List<PersonelUserAdvertFollowDTO> GetAllDTO();
        List<PersonelUserAdvertFollowDTO> GetAllByCompanyIdDTO(string id);
        List<PersonelUserAdvertFollowDTO> GetAllByPersonelIdDTO(string id);
    }
}
