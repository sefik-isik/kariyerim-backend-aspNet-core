using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITaxOfficeService
    {
        IResult Add(TaxOffice taxOffice);
        IResult Update(TaxOffice taxOffice);
        IResult Delete(TaxOffice taxOffice);
        IDataResult<List<TaxOffice>> GetAll();
        IDataResult<List<TaxOffice>> GetDeletedAll();
        IDataResult<TaxOffice> GetById(int id);

        //DTO
        IDataResult<List<TaxOfficeDTO>> GetAllDTO();
        IDataResult<List<TaxOfficeDTO>> GetAllDeletedDTO();

    }
}
