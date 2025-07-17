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
        IResult Add(PersonelUserAdvertFollow personelUserAdvertFollow);
        IResult Terminate(PersonelUserAdvertFollow personelUserAdvertFollow);
        IDataResult<List<PersonelUserAdvertFollow>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUserAdvertFollow> GetById(string id);

        //dto
        IDataResult<List<PersonelUserAdvertFollowDTO>> GetAllDTO(string id);
        IDataResult<List<PersonelUserAdvertFollowDTO>> GetAllByAdvertIdDTO(string id);
        IDataResult<List<PersonelUserAdvertFollowDTO>> GetAllByPersonelIdDTO(string id);
    }
}
