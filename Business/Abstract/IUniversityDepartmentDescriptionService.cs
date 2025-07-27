using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUniversityDepartmentDescriptionService
    {
        IResult Add(UniversityDepartmentDescription universityDepartmentDescription);
        IResult Update(UniversityDepartmentDescription universityDepartmentDescription);
        IResult Delete(UniversityDepartmentDescription universityDepartmentDescription);
        IResult Terminate(UniversityDepartmentDescription universityDepartmentDescription);
        IDataResult<List<UniversityDepartmentDescription>> GetAll();
        IDataResult<List<UniversityDepartmentDescription>> GetDeletedAll();
        IDataResult<UniversityDepartmentDescription> GetById(string id);

        //DTO
        IDataResult<List<UniversityDepartmentDescriptionDTO>> GetAllDTO();
        IDataResult<List<UniversityDepartmentDescriptionDTO>> GetDeletedAllDTO();
        IDataResult<List<UniversityDepartmentDescriptionDTO>> GetAllByUniversityDeparttmetIdDTO(string id);

    }
}
