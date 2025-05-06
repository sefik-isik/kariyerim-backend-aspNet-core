using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFacultyService
    {
        IResult Add(Faculty faculty);
        IResult Update(Faculty faculty);
        IResult Delete(Faculty faculty);
        IDataResult<List<Faculty>> GetAll();IDataResult<List<Faculty>> GetDeletedAll();
        IDataResult<Faculty> GetById(int facultyId);
        
    }
}
