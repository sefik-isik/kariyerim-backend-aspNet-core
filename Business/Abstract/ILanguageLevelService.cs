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
        Task<IResult> Add(LanguageLevel languageLevel);
        Task<IResult> Update(LanguageLevel languageLevel);
        Task<IResult> Delete(LanguageLevel languageLevel);
        Task<IResult> Terminate(LanguageLevel languageLevel);
        Task<IDataResult<List<LanguageLevel>>> GetAll();
        Task<IDataResult<List<LanguageLevel>>> GetDeletedAll();
        Task<IDataResult<LanguageLevel>> GetById(string id);
        
    }
}
