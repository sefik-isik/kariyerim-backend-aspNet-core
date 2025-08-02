using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUniversityFacultyService
    {
        Task<IResult> Add(UniversityFaculty universityFaculty);
        Task<IResult> Update(UniversityFaculty universityFaculty);
        Task<IResult> Delete(UniversityFaculty universityFaculty);
        Task<IResult> Terminate(UniversityFaculty universityFaculty);
        Task<IDataResult<List<UniversityFaculty>>> GetAll();
        Task<IDataResult<List<UniversityFaculty>>> GetDeletedAll();
        Task<IDataResult<UniversityFaculty>> GetById(string id);
    }
}
