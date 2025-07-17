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
    public interface IPersonelUserAdvertApplicationService
    {
        IResult Add(PersonelUserAdvertApplication personelUserAdvertApplication);
        IResult Terminate(PersonelUserAdvertApplication personelUserAdvertApplication);
        IDataResult<List<PersonelUserAdvertApplication>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<PersonelUserAdvertApplication> GetById(string id);

        //dto
        IDataResult<List<PersonelUserAdvertApplicationDTO>> GetAllDTO(string id);
        IDataResult<List<PersonelUserAdvertApplicationDTO>> GetAllByAdvertIdDTO(string id);
        IDataResult<List<PersonelUserAdvertApplicationDTO>> GetAllByPersonelIdDTO(string id);
    }
}
