using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILanguageLevelService
    {
        IResult Add(LanguageLevel languageLevel);
        IResult Update(LanguageLevel languageLevel);
        IResult Delete(LanguageLevel languageLevel);
        IDataResult<List<LanguageLevel>> GetAll();
        IDataResult<List<LanguageLevel>> GetDeletedAll();
        IDataResult<LanguageLevel> GetById(int id);
        
    }
}
