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
    public interface ISectorDescriptionDal : IEntityRepository<SectorDescription>
    {
        Task<List<SectorDescriptionDTO>> GetAllDTO();
        Task<List<SectorDescriptionDTO>> GetDeletedAllDTO();
        Task<List<SectorDescriptionDTO>> GetAllBySectorIdDTO(string id);
    }
}
