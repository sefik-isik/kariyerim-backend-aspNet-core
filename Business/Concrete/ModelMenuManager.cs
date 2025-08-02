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
        public async Task<IResult> Add(ModelMenu modelMenu)
        {
            IResult result = await BusinessRules.Run(IsNameExist(modelMenu.ModelName));

            if (result != null)
            {
                return result;
            }
            await _modelMenuDal.AddAsync(modelMenu);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Update(ModelMenu modelMenu)
        {
            await _modelMenuDal.UpdateAsync(modelMenu);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Delete(ModelMenu modelMenu)
        {
            await _modelMenuDal.Delete(modelMenu);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(ModelMenu modelMenu)
        {
            await _modelMenuDal.Terminate(modelMenu);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<ModelMenu>>> GetAll()
        {
            var result = await _modelMenuDal.GetAll();
            result = result.OrderBy(x => x.ModelName).ToList();
            return new SuccessDataResult<List<ModelMenu>>(result, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<ModelMenu>>> GetDeletedAll()
        {
            var result = await _modelMenuDal.GetDeletedAll();
            result = result.OrderBy(x => x.ModelName).ToList();
            return new SuccessDataResult<List<ModelMenu>>(result, Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<ModelMenu?>> GetById(string id)
        {
            return new SuccessDataResult<ModelMenu?>(await _modelMenuDal.Get(g => g.Id == id));
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _modelMenuDal.GetAll(c => c.ModelName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
