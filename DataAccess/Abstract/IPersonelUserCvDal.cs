using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPersonelUserCvDal : IEntityRepository<PersonelUserCv>
    {
        Task TerminateSubDatas(string id);
        List<PersonelUserCvDTO> GetAllDTO();
        List<PersonelUserCvDTO> GetDeletedAllDTO();
    }
}
