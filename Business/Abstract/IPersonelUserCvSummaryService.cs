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
    public interface IPersonelUserCvSummaryService
    {
        IResult Add(PersonelUserCvSummary cvSummary);
        IResult Update(PersonelUserCvSummary cvSummary);
        IResult Delete(PersonelUserCvSummary cvSummary);
        IDataResult<List<PersonelUserCvSummary>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserCvSummary>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUserCvSummary> GetById(int id);
        
    }
}
