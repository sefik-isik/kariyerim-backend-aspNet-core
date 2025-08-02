using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITaxOfficeService
    {
        Task<IResult> Add(TaxOffice taxOffice);
        Task<IResult> Update(TaxOffice taxOffice);
        Task<IResult> Delete(TaxOffice taxOffice);
        Task<IResult> Terminate(TaxOffice taxOffice);
        Task<IDataResult<List<TaxOffice>>> GetAll();
        Task<IDataResult<List<TaxOffice>>> GetDeletedAll();
        Task<IDataResult<TaxOffice>> GetById(string id);
        Task<IDataResult<TaxOfficePageModel>> GetAllByPage(TaxOfficePageModel pageModel);

        //DTO
        Task<IDataResult<List<TaxOfficeDTO>>> GetAllDTO();
        Task<IDataResult<List<TaxOfficeDTO>>> GetDeletedAllDTO();

    }
}
