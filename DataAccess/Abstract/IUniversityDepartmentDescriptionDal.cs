using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUniversityDepartmentDescriptionDal : IEntityRepository<UniversityDepartmentDescription>
    {
        Task<List<UniversityDepartmentDescriptionDTO>> GetAllDTO();
        Task<List<UniversityDepartmentDescriptionDTO>> GetDeletedAllDTO();
        Task<List<UniversityDepartmentDescriptionDTO>> GetAllByUniversityDepartmentIdDTO(string id);
    }
}
