using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        Task<IResult> Add(Language language);
        Task<IResult> Update(Language language);
        Task<IResult> Delete(Language language);
        Task<IResult> Terminate(Language language);
        Task<IDataResult<List<Language>>> GetAll();
        Task<IDataResult<List<Language>>> GetDeletedAll();
        Task<IDataResult<Language>> GetById(string id);
        
    }
}
