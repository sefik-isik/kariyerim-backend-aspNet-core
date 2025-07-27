using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TaxOfficeManager: ITaxOfficeService
    {
        ITaxOfficeDal _taxOfficeDal;

        public TaxOfficeManager(ITaxOfficeDal taxOfficeDal)
        {
            _taxOfficeDal = taxOfficeDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(TaxOffice taxOffice)
        {
            IResult result = BusinessRules.Run(IsNameExist(taxOffice.TaxOfficeName),IsCodeExist(taxOffice.TaxOfficeName));

            if (result != null)
            {
                return result;
            }
            _taxOfficeDal.AddAsync(taxOffice);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(TaxOffice taxOffice)
        {
            _taxOfficeDal.UpdateAsync(taxOffice);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(TaxOffice taxOffice)
        {
            _taxOfficeDal.Delete(taxOffice);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(TaxOffice taxOffice)
        {
            _taxOfficeDal.Terminate(taxOffice);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<TaxOffice>> GetAll()
        {
            return new SuccessDataResult<List<TaxOffice>>(_taxOfficeDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<TaxOffice>> GetDeletedAll()
        {
            return new SuccessDataResult<List<TaxOffice>>(_taxOfficeDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<TaxOffice> GetById(string id)
        {
            return new SuccessDataResult<TaxOffice>(_taxOfficeDal.Get(t=>t.Id == id));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<TaxOfficeDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<TaxOfficeDTO>>(_taxOfficeDal.GetAllDTO().OrderBy(s => s.CityName).ToList(), Messages.SuccessListed);
        }
        public IDataResult<List<TaxOfficeDTO>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<TaxOfficeDTO>>(_taxOfficeDal.GetDeletedAllDTO().OrderBy(s => s.CityName).ToList(), Messages.SuccessListed);
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _taxOfficeDal.GetAll(c => c.TaxOfficeName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult IsCodeExist(string entityName)
        {
            var result = _taxOfficeDal.GetAll(c => c.TaxOfficeCode.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
