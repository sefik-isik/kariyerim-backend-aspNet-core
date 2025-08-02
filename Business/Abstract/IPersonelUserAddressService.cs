using Core.Entities.Concrete;
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
        Task<IResult> Add(PersonelUserAddress personelUserAddress);
        Task<IResult> Update(PersonelUserAddress personelUserAddress);
        Task<IResult> Delete(PersonelUserAddress personelUserAddress);
        Task<IResult> Terminate(PersonelUserAddress personelUserAddress);
        Task<IDataResult<List<PersonelUserAddress>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserAddress>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUserAddress>> GetById(UserAdminDTO userAdminDTO);


        //DTO
        Task<IDataResult<List<PersonelUserAddressDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserAddressDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
    }
}
