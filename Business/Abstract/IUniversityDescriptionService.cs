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
        IResult Add(UniversityDescription universityDepartment);
        IResult Update(UniversityDescription universityDepartment);
        IResult Delete(UniversityDescription universityDepartment);
        IResult Terminate(UniversityDescription universityDepartment);
        IDataResult<List<UniversityDescription>> GetAll();
        IDataResult<List<UniversityDescription>> GetDeletedAll();
        IDataResult<UniversityDescription> GetById(string id);

        //DTO
        IDataResult<List<UniversityDescriptionDTO>> GetAllDTO();
        IDataResult<List<UniversityDescriptionDTO>> GetDeletedAllDTO();
        IDataResult<List<UniversityDescriptionDTO>> GetAllByUniversityIdDTO(string id);
    }
}
