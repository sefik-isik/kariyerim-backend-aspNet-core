using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonelUserCvService
    {
        IResult Add(PersonelUserCv cv);
        IResult Update(PersonelUserCv cv);
        IResult Delete(PersonelUserCv cv);
        IDataResult<List<PersonelUserCv>> GetAll(int UserId);
        IDataResult<PersonelUserCv> GetById(int cvId);
        
    }
}
