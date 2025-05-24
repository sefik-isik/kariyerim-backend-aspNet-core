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
    public interface IUniversityFacultyService
    {
        IResult Add(UniversityFaculty universityFaculty);
        IResult Update(UniversityFaculty universityFaculty);
        IResult Delete(UniversityFaculty universityFaculty);
        IDataResult<List<UniversityFaculty>> GetAll();
        IDataResult<List<UniversityFaculty>> GetDeletedAll();
        IDataResult<UniversityFaculty> GetById(int id);

        //DTO
        IDataResult<List<UniversityFacultyDTO>> GetAllDTO();
        IDataResult<List<UniversityFacultyDTO>> GetDeletedAllDTO();
    }
}
