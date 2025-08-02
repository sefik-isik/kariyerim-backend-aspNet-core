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
    public interface IPersonelUserAdvertFollowService
    {
        Task<IResult> Add(PersonelUserAdvertFollow personelUserAdvertFollow);
        Task<IResult> Terminate(PersonelUserAdvertFollow personelUserAdvertFollow);
        Task<IDataResult<List<PersonelUserAdvertFollow>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUserAdvertFollow>> GetById(string id);

        //dto
        Task<IDataResult<List<PersonelUserAdvertFollowDTO>>> GetAllDTO(string id);
        Task<IDataResult<List<PersonelUserAdvertFollowDTO>>> GetAllByAdvertIdDTO(string id);
        Task<IDataResult<List<PersonelUserAdvertFollowDTO>>> GetAllByPersonelIdDTO(string id);
    }
}
