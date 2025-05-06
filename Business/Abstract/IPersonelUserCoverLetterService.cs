using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonelUserCoverLetterService
    {
        IResult Add(PersonelUserCoverLetter personelUserCoverLetter);
        IResult Update(PersonelUserCoverLetter personelUserCoverLetter);
        IResult Delete(PersonelUserCoverLetter personelUserCoverLetter);
        IDataResult<List<PersonelUserCoverLetter>> GetAll(int UserId);IDataResult<List<PersonelUserCoverLetter>> GetDeletedAll(int UserId);
        IDataResult<PersonelUserCoverLetter> GetById(int personelUserCoverLetterId);
        
    }
}
