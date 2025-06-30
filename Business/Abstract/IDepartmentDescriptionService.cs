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
    public interface IDepartmentDescriptionService
    {
        IResult Add(DepartmentDescription departmentDescription);
        IResult Update(DepartmentDescription departmentDescription);
        IResult Delete(DepartmentDescription departmentDescription);
        IResult Terminate(DepartmentDescription departmentDescription);
        IDataResult<List<DepartmentDescription>> GetAll();
        IDataResult<List<DepartmentDescription>> GetDeletedAll();
        IDataResult<DepartmentDescription> GetById(string id);

        //DTO
        IDataResult<List<DepartmentDescriptionDTO>> GetAllDTO();
        IDataResult<List<DepartmentDescriptionDTO>> GetDeletedAllDTO();

    }
}
