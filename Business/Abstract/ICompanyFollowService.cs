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
    public interface ICompanyFollowService
    {
        IResult Add(CompanyFollow companyFollow);
        IResult Terminate(CompanyFollow companyFollow);
        IDataResult<List<CompanyFollow>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<CompanyFollow> GetById(string id);
        IDataResult<List<CompanyFollow>> GetAllByCompanyId(string id);
        IDataResult<List<CompanyFollow>> GetAllByPersonelId(string id);

        //dto
        IDataResult<List<CompanyFollowDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<CompanyFollowDTO>> GetAllByCompanyIdDTO(string id);
        IDataResult<List<CompanyFollowDTO>> GetAllByPersonelIdDTO(string id);
    }
}
