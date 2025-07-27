using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
            IResult result = BusinessRules.Run(IsLevelExist(languageLevel.Level), IsLevelTitleExist(languageLevel.LevelTitle));

            if (result != null)
            {
                return result;
            }
            _languageLevelDal.AddAsync(languageLevel);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(LanguageLevel languageLevel)
        {
            _languageLevelDal.UpdateAsync(languageLevel);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(LanguageLevel languageLevel)
        {
            _languageLevelDal.Delete(languageLevel);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(LanguageLevel languageLevel)
        {
            _languageLevelDal.Terminate(languageLevel);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<LanguageLevel>> GetAll()
        {
            return new SuccessDataResult<List<LanguageLevel>>(_languageLevelDal.GetAll().OrderBy(s => s.LevelTitle).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<LanguageLevel>> GetDeletedAll()
        {
            return new SuccessDataResult<List<LanguageLevel>>(_languageLevelDal.GetDeletedAll().OrderBy(s => s.LevelTitle).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<LanguageLevel> GetById(string id)
        {
            return new SuccessDataResult<LanguageLevel>(_languageLevelDal.Get(l=>l.Id == id));
        }

        //Business Rules
        private IResult IsLevelExist(int entityName)
        {
            var result = _languageLevelDal.GetAll(c => c.Level == entityName).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult IsLevelTitleExist(string entityName)
        {
            var result = _languageLevelDal.GetAll(c => c.LevelTitle.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }


    }
}
