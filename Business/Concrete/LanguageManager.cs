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
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Core.Utilities.Business;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

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
        [ValidationAspect(typeof(LanguageValidator))]
        public IResult Add(Language language)
        {
            IResult result = BusinessRules.Run(IsNameExist(language.LanguageName));

            if (result != null)
            {
                return result;
            }
            _languageDal.AddAsync(language);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(Language language)
        {
            _languageDal.UpdateAsync(language);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(Language language)
        {  
            _languageDal.Delete(language);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(Language language)
        {
            _languageDal.Terminate(language);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Language>> GetAll()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll().OrderBy(s => s.LanguageName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Language>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetDeletedAll().OrderBy(s => s.LanguageName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Language> GetById(string id)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(l => l.Id == id));
        }
        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _languageDal.GetAll(c => c.LanguageName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
