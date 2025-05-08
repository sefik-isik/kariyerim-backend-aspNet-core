using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
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
            _modelMenuDal.Add(modelMenu);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(ModelMenu modelMenu)
        {
            _modelMenuDal.Update(modelMenu);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(ModelMenu modelMenu)
        {
            _modelMenuDal.Delete(modelMenu);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<ModelMenu>> GetAll()
        {
            return new SuccessDataResult<List<ModelMenu>>(_modelMenuDal.GetAll());
        }
        [SecuredOperation("admin")]
        public IDataResult<List<ModelMenu>> GetDeletedAll()
        {
            return new SuccessDataResult<List<ModelMenu>>(_modelMenuDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<ModelMenu> GetById(int id)
        {
            return new SuccessDataResult<ModelMenu>(_modelMenuDal.Get(g => g.Id == id));
        }
    }
}
