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
        public IResult Add(Experience experience)
        {
            IResult result = BusinessRules.Run(IsNameExist(experience.ExperienceName));

            if (result != null)
            {
                return result;
            }
            _experienceDal.AddAsync(experience);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(Experience experience)
        {
            _experienceDal.UpdateAsync(experience);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(Experience experience)
        {
            _experienceDal.Delete(experience);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(Experience experience)
        {
            _experienceDal.Terminate(experience);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Experience>> GetAll()
        {
            return new SuccessDataResult<List<Experience>>(_experienceDal.GetAll().OrderBy(s => s.ExperienceName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<Experience>> GetDeletedAll()
        {
            return new SuccessDataResult<List<Experience>>(_experienceDal.GetDeletedAll().OrderBy(s => s.ExperienceName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<Experience> GetById(string id)
        {
            return new SuccessDataResult<Experience>(_experienceDal.Get(f => f.Id == id));
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _experienceDal.GetAll(c => c.ExperienceName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
