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
        Task<IResult> Add(PersonelUserAdvertApplication personelUserAdvertApplication);
        Task<IResult> Terminate(PersonelUserAdvertApplication personelUserAdvertApplication);
        Task<IDataResult<List<PersonelUserAdvertApplication>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<PersonelUserAdvertApplication>> GetById(string id);
        Task<IDataResult<List<PersonelUserAdvertApplication>>> GetAllByCompanyId(string id);
        Task<IDataResult<List<PersonelUserAdvertApplication>>> GetAllByPersonelId(string id);

        //dto
        Task<IDataResult<List<PersonelUserAdvertApplicationDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserAdvertApplicationDTO>>> GetAllByCompanyUserIdDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserAdvertApplicationDTO>>> GetAllByPersonelUserIdDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<PersonelUserAdvertApplicationDTO>>> GetAllByAdvertIdDTO(UserAdminDTO userAdminDTO);
    }
}
