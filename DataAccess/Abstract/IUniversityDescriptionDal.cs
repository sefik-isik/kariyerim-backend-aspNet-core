using Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUniversityDescriptionDal : IEntityRepository<UniversityDescription>
    {
        Task<List<UniversityDescriptionDTO>> GetAllDTO();
        Task<List<UniversityDescriptionDTO>> GetDeletedAllDTO();
        Task<List<UniversityDescriptionDTO>> GetAllByUniversityIdDTO(string id);
    }
}
