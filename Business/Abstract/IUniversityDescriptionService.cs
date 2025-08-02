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
    public interface IUniversityDescriptionService
    {
        Task<IResult> Add(UniversityDescription universityDepartment);
        Task<IResult> Update(UniversityDescription universityDepartment);
        Task<IResult> Delete(UniversityDescription universityDepartment);
        Task<IResult> Terminate(UniversityDescription universityDepartment);
        Task<IDataResult<List<UniversityDescription>>> GetAll();
        Task<IDataResult<List<UniversityDescription>>> GetDeletedAll();
        Task<IDataResult<UniversityDescription>> GetById(string id);

        //DTO
        Task<IDataResult<List<UniversityDescriptionDTO>>> GetAllDTO();
        Task<IDataResult<List<UniversityDescriptionDTO>>> GetDeletedAllDTO();
        Task<IDataResult<List<UniversityDescriptionDTO>>> GetAllByUniversityIdDTO(string id);
    }
}
