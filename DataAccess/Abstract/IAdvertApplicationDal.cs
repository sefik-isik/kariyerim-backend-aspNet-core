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
    public interface IAdvertApplicationDal : IEntityRepository<AdvertApplication>
    {
        List<AdvertApplicationDTO> GetAllDTO();
        List<AdvertApplicationDTO> GetAllByCompanyIdDTO(string id);
        List<AdvertApplicationDTO> GetAllByPersonelIdDTO(string id);
    }
}
