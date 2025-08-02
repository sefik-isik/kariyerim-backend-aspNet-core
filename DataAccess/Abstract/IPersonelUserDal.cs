using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPersonelUserDal : IEntityRepository<PersonelUser>
    {
        Task TerminateSubDatas(string id);
        Task<List<PersonelUserDTO>> GetAllDTO();
        Task<List<PersonelUserDTO>> GetDeletedAllDTO();
    }
}
