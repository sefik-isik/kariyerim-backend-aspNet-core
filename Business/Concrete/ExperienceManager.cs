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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal _experienceDal;
        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Add(Experience experience)
        {
            IResult result = await BusinessRules.Run(IsNameExist(experience.ExperienceName));

            if (result != null)
            {
                return result;
            }
            await _experienceDal.AddAsync(experience);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(Experience experience)
        {
            await _experienceDal.UpdateAsync(experience);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(Experience experience)
        {
            await _experienceDal.Delete(experience);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(Experience experience)
        {
            await _experienceDal.Terminate(experience);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Experience>>> GetAll()
        {
            var result = await _experienceDal.GetAll();
            result = result.OrderBy(x => x.ExperienceName).ToList();
            return new SuccessDataResult<List<Experience>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<Experience>>> GetDeletedAll()
        {
            var result = await _experienceDal.GetDeletedAll();
            result = result.OrderBy(x => x.ExperienceName).ToList();
            return new SuccessDataResult<List<Experience>>(result, Messages.SuccessListed);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<Experience?>> GetById(string id)
        {
            return new SuccessDataResult<Experience?>(await _experienceDal.Get(f => f.Id == id));
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _experienceDal.GetAll(c => c.ExperienceName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
