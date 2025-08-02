using Core.Utilities.Results;
using Entities.Concrete;
using Entities.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUniversityDepartmentService
    {
        Task<IResult> Add(UniversityDepartment universityDepartment);
        Task<IResult> Update(UniversityDepartment universityDepartment);
        Task<IResult> Delete(UniversityDepartment universityDepartment);
        Task<IResult> Terminate(UniversityDepartment universityDepartment);
        Task<IDataResult<List<UniversityDepartment>>> GetAll();
        Task<IDataResult<List<UniversityDepartment>>> GetDeletedAll();
        Task<IDataResult<UniversityDepartment>> GetById(string id);
        Task<IDataResult<UniversityDepartmentPageModel>> GetAllByPage(UniversityDepartmentPageModel pageModel);
    }
}
