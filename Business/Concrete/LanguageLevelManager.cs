using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LanguageLevelManager : ILanguageLevelService
    {
        ILanguageLevelDal _languageLevelDal;

        public LanguageLevelManager(ILanguageLevelDal languageLevelDal)
        {
            _languageLevelDal = languageLevelDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(LanguageLevel languageLevel)
        {
            _languageLevelDal.Add(languageLevel);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(LanguageLevel languageLevel)
        {
            _languageLevelDal.Update(languageLevel);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(LanguageLevel languageLevel)
        {
            _languageLevelDal.Delete(languageLevel);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<LanguageLevel>> GetAll()
        {
            return new SuccessDataResult<List<LanguageLevel>>(_languageLevelDal.GetAll().OrderBy(s => s.LevelTitle).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<LanguageLevel>> GetDeletedAll()
        {
            return new SuccessDataResult<List<LanguageLevel>>(_languageLevelDal.GetDeletedAll().OrderBy(s => s.LevelTitle).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<LanguageLevel> GetById(int id)
        {
            return new SuccessDataResult<LanguageLevel>(_languageLevelDal.Get(l=>l.Id == id));
        }

        
    }
}
