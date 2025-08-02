using Core.Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICityDal :IEntityRepository<City>
    {
        Task TerminateSubDatas(string id);
        Task<List<CityDTO>> GetAllDTO();
        Task<List<CityDTO>> GetDeletedAllDTO();
    }
}
