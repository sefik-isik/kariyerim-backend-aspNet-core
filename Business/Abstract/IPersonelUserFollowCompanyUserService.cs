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
    public interface IPersonelUserFollowCompanyUserService
    {
        IResult Add(PersonelUserFollowCompanyUser personelUserFollowCompanyUser);
        IResult Terminate(PersonelUserFollowCompanyUser personelUserFollowCompanyUser);
        IDataResult<List<PersonelUserFollowCompanyUser>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUserFollowCompanyUser> GetById(string id);
        IDataResult<List<PersonelUserFollowCompanyUser>> GetAllByCompanyId(string id);
        IDataResult<List<PersonelUserFollowCompanyUser>> GetAllByPersonelId(string id);

        //dto
        IDataResult<List<PersonelUserFollowCompanyUserDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserFollowCompanyUserDTO>> GetAllByCompanyIdDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserFollowCompanyUserDTO>> GetAllByPersonelIdDTO(UserAdminDTO userAdminDTO);
    }
}
