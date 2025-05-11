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
        IDataResult<List<PersonelUserAddress>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserAddress>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUserAddress> GetById(UserAdminDTO userAdminDTO);


        //DTO
        IDataResult<List<PersonelUserAddressDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<PersonelUserAddressDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO);
    }
}
