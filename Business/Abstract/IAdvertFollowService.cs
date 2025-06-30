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
    public interface IAdvertFollowService
    {
        IResult Add(AdvertFollow advertFollow);
        IResult Terminate(AdvertFollow advertFollow);
        IDataResult<List<AdvertFollow>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<AdvertFollow> GetById(string id);
        IDataResult<List<AdvertFollow>> GetAllByCompanyId(string id);
        IDataResult<List<AdvertFollow>> GetAllByPersonelId(string id);

        //dto
        IDataResult<List<AdvertFollowDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<AdvertFollowDTO>> GetAllByCompanyIdDTO(string id);
        IDataResult<List<AdvertFollowDTO>> GetAllByPersonelIdDTO(string id);
    }
}
