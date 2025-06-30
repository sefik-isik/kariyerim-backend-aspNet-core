using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        IResult Add(Department department);
        IResult Update(Department department);
        IResult Delete(Department department);
        IResult Terminate(Department department);
        IDataResult<List<Department>> GetAll();
        IDataResult<List<Department>> GetDeletedAll();
        IDataResult<Department> GetById(string id);
    }
}
