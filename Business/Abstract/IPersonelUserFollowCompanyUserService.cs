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
        Task<IResult> Add(PersonelUserFollowCompanyUser personelUserFollowCompanyUser);
        Task<IResult> Terminate(PersonelUserFollowCompanyUser personelUserFollowCompanyUser);
        Task<IDataResult<List<PersonelUserFollowCompanyUser>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUserFollowCompanyUser>> GetById(string id);
        Task<IDataResult<List<PersonelUserFollowCompanyUser>>> GetAllByCompanyId(string id);
        Task<IDataResult<List<PersonelUserFollowCompanyUser>>> GetAllByPersonelId(string id);

        //dto
        Task<IDataResult<List<PersonelUserFollowCompanyUserDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserFollowCompanyUserDTO>>> GetAllByCompanyUserIdDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserFollowCompanyUserDTO>>> GetAllByPersonelUserIdDTO(UserAdminDTO userAdminDTO);
    }
}
