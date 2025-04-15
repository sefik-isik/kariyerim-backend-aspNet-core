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
        IDataResult<List<PersonelUser>> GetAll(int UserId);
        IDataResult<PersonelUser> GetById(int personelUserId);

        //DTO
        IDataResult<List<PersonelUserDTO>> GetPersonelUserDTO(int userId);
        IDataResult<List<PersonelUserDTO>> GetPersonelUserDeletedDTO(int userId);
    }
}
