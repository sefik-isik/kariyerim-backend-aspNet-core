﻿using Core.DataAccess;
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
        List<UniversityDepartmentDescriptionDTO> GetAllDTO();
        List<UniversityDepartmentDescriptionDTO> GetDeletedAllDTO();
        List<UniversityDepartmentDescriptionDTO> GetAllByUniversityDepartmentIdDTO(string id);
    }
}
