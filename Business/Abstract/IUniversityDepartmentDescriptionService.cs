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
        Task<IResult> Add(UniversityDepartmentDescription universityDepartmentDescription);
        Task<IResult> Update(UniversityDepartmentDescription universityDepartmentDescription);
        Task<IResult> Delete(UniversityDepartmentDescription universityDepartmentDescription);
        Task<IResult> Terminate(UniversityDepartmentDescription universityDepartmentDescription);
        Task<IDataResult<List<UniversityDepartmentDescription>>> GetAll();
        Task<IDataResult<List<UniversityDepartmentDescription>>> GetDeletedAll();
        Task<IDataResult<UniversityDepartmentDescription>> GetById(string id);

        //DTO
        Task<IDataResult<List<UniversityDepartmentDescriptionDTO>>> GetAllDTO();
        Task<IDataResult<List<UniversityDepartmentDescriptionDTO>>> GetDeletedAllDTO();
        Task<IDataResult<List<UniversityDepartmentDescriptionDTO>>> GetAllByUniversityDeparttmetIdDTO(string id);

    }
}
