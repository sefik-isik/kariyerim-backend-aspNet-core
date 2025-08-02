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
        public async Task<IResult> Add(LanguageLevel languageLevel)
        {
            IResult result = await BusinessRules.Run(IsLevelExist(languageLevel.Level), await IsLevelTitleExist(languageLevel.LevelTitle));

            if (result != null)
            {
                return result;
            }
            await _languageLevelDal.AddAsync(languageLevel);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(LanguageLevel languageLevel)
        {
            await _languageLevelDal.UpdateAsync(languageLevel);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(LanguageLevel languageLevel)
        {
            await _languageLevelDal.Delete(languageLevel);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(LanguageLevel languageLevel)
        {
            await _languageLevelDal.Terminate(languageLevel);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<LanguageLevel>>> GetAll()
        {
            var result = await _languageLevelDal.GetAll();
            result = result.OrderBy(x => x.LevelTitle).ToList();
            return new SuccessDataResult<List<LanguageLevel>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<LanguageLevel>>> GetDeletedAll()
        {
            var result = await _languageLevelDal.GetDeletedAll();
            result = result.OrderBy(x => x.LevelTitle).ToList();
            return new SuccessDataResult<List<LanguageLevel>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<LanguageLevel?>> GetById(string id)
        {
            return new SuccessDataResult<LanguageLevel?>(await _languageLevelDal.Get(l=>l.Id == id));
        }

        //Business Rules
        private async Task<IResult> IsLevelExist(int entityName)
        {
            var result = await _languageLevelDal.GetAll(c => c.Level == entityName);

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

        private async Task<IResult> IsLevelTitleExist(string entityName)
        {
            var result = await _languageLevelDal.GetAll(c => c.LevelTitle.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }


    }
}
