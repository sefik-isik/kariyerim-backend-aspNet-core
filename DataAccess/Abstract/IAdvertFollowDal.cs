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
    public interface IAdvertFollowDal : IEntityRepository<AdvertFollow>
    {
        List<AdvertFollowDTO> GetAllDTO();
        List<AdvertFollowDTO> GetAllByCompanyIdDTO(string id);
        List<AdvertFollowDTO> GetAllByPersonelIdDTO(string id);
    }
}
