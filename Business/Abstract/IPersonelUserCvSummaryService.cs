using Core.Utilities.Results;
using Entities.Concrete;
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
        IDataResult<List<PersonelUserCvSummary>> GetAll(int UserId);
        IDataResult<PersonelUserCvSummary> GetById(int cvSummaryId);
        
    }
}
