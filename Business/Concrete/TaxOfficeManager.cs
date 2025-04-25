using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
            _taxOfficeDal.Add(taxOffice);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(TaxOffice taxOffice)
        {
            _taxOfficeDal.Update(taxOffice);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(TaxOffice taxOffice)
        {
            _taxOfficeDal.Delete(taxOffice);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<TaxOffice>> GetAll()
        {
            return new SuccessDataResult<List<TaxOffice>>(_taxOfficeDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<TaxOffice> GetById(int taxOfficeId)
        {
            return new SuccessDataResult<TaxOffice>(_taxOfficeDal.Get(t=>t.Id == taxOfficeId));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<TaxOfficeDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<TaxOfficeDTO>>(_taxOfficeDal.GetAllDTO());
        }

    }
}
