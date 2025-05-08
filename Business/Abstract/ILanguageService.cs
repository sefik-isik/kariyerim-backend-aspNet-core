using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        IResult Add(Language language);
        IResult Update(Language language);
        IResult Delete(Language language);
        IDataResult<List<Language>> GetAll();
        IDataResult<List<Language>> GetDeletedAll();
        IDataResult<Language> GetById(int id);
        
    }
}
