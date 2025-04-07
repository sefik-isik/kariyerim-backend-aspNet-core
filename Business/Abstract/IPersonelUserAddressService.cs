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
    public interface IPersonelUserAddressService
    {
        IResult Add(PersonelUserAddress personelUserAddress);
        IResult Update(PersonelUserAddress personelUserAddress);
        IResult Delete(PersonelUserAddress personelUserAddress);
        IDataResult<List<PersonelUserAddress>> GetAll(int UserId);
        IDataResult<PersonelUserAddress> GetById(int personelUserAddressId);
        

        //DTO
        IDataResult<List<PersonelUserAddressDTO>> GetUserAddressDTO(int userId);
        IDataResult<List<PersonelUserAddressDTO>> GetUserAddressDeletedDTO(int userId);
    }
}
