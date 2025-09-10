using Core.Entities.Abstract;
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
    public interface IPersonelUserService
    {
        Task<IResult> Add(PersonelUser personelUser);
        Task<IResult> Update(PersonelUser personelUser);
        Task<IResult> Delete(PersonelUser personelUser);
        Task<IResult> Terminate(PersonelUser personelUser);
        Task<IDataResult<List<PersonelUser>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUser>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUser>> GetByUserId(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUser>> GetById(string id);
        Task<IDataResult<PersonelUserPageModel>> GetAllByPage(PersonelUserPageModel pageModel);

        //DTO
        Task<IDataResult<List<PersonelUserDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
