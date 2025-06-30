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
    public interface IAdvertApplicationService
    {
        IResult Add(AdvertApplication advertApplication);
        IResult Terminate(AdvertApplication advertApplication);
        IDataResult<List<AdvertApplication>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<AdvertApplication> GetById(string id);

        //dto
        IDataResult<List<AdvertApplicationDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<AdvertApplicationDTO>> GetAllByCompanyIdDTO(string id);
        IDataResult<List<AdvertApplicationDTO>> GetAllByPersonelIdDTO(string id);
    }
}
