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
    public interface IUniversityDepartmentService
    {
        IResult Add(UniversityDepartment universityDepartment);
        IResult Update(UniversityDepartment universityDepartment);
        IResult Delete(UniversityDepartment universityDepartment);
        IDataResult<List<UniversityDepartment>> GetAll();
        IDataResult<List<UniversityDepartment>> GetDeletedAll();
        IDataResult<UniversityDepartment> GetById(int id);
        

        //DTO
        IDataResult<List<UniversityDepartmentDTO>> GetAllDTO();
        IDataResult<List<UniversityDepartmentDTO>> GetAllDeletedDTO();
    }
}
