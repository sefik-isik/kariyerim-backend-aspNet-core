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
        public async Task<IResult> Add(Language language)
        {
            IResult result = await BusinessRules.Run(IsNameExist(language.LanguageName));

            if (result != null)
            {
                return result;
            }
            await _languageDal.AddAsync(language);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(Language language)
        {
            await _languageDal.UpdateAsync(language);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(Language language)
        {
            await _languageDal.Delete(language);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(Language language)
        {
            await _languageDal.Terminate(language);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Language>>> GetAll()
        {
            var result = await _languageDal.GetAll();
            result = result.OrderBy(x => x.LanguageName).ToList();
            return new SuccessDataResult<List<Language>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Language>>> GetDeletedAll()
        {
            var result = await _languageDal.GetDeletedAll();
            result = result.OrderBy(x => x.LanguageName).ToList();
            return new SuccessDataResult<List<Language>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<Language?>> GetById(string id)
        {
            return new SuccessDataResult<Language?>(await _languageDal.Get(l => l.Id == id));
        }
        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _languageDal.GetAll(c => c.LanguageName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
