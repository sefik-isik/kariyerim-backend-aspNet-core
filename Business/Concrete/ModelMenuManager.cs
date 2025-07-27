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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ModelMenuManager : IModelMenuService
    {
        IModelMenuDal _modelMenuDal;

        public ModelMenuManager(IModelMenuDal modelMenuDal)
        {
            _modelMenuDal = modelMenuDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(ModelMenu modelMenu)
        {
            IResult result = BusinessRules.Run(IsNameExist(modelMenu.ModelName));

            if (result != null)
            {
                return result;
            }
            _modelMenuDal.AddAsync(modelMenu);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(ModelMenu modelMenu)
        {
            _modelMenuDal.UpdateAsync(modelMenu);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(ModelMenu modelMenu)
        {
            _modelMenuDal.Delete(modelMenu);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(ModelMenu modelMenu)
        {
            _modelMenuDal.Terminate(modelMenu);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<ModelMenu>> GetAll()
        {
            return new SuccessDataResult<List<ModelMenu>>(_modelMenuDal.GetAll().OrderBy(s => s.ModelName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<ModelMenu>> GetDeletedAll()
        {
            return new SuccessDataResult<List<ModelMenu>>(_modelMenuDal.GetDeletedAll().OrderBy(s => s.ModelName).ToList(), Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<ModelMenu> GetById(string id)
        {
            return new SuccessDataResult<ModelMenu>(_modelMenuDal.Get(g => g.Id == id));
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _modelMenuDal.GetAll(c => c.ModelName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
