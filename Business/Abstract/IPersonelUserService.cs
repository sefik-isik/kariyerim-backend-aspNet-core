using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Business.Abstract
{
    public interface IPersonelUserService
    {
        IResult Add(PersonelUser personelUser);
        IResult Update(PersonelUser personelUser);
        IResult Delete(PersonelUser personelUser);
        IDataResult<List<PersonelUser>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUser>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUser> GetById(int id);
        IDataResult<PersonelUser> GetByUserId(int id);

        //DTO
        IDataResult<List<PersonelUserDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO);
    }
}
