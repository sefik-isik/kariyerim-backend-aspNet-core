using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class LanguageManager: ILanguageService
    {
        ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(Language language)
        {
            _languageDal.Add(language);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(Language language)
        {
            _languageDal.Update(language);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(Language language)
        {  
            _languageDal.Delete(language);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Language>> GetAll()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Language> GetById(int languageId)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(l => l.Id == languageId));
        }

        
    }
}
