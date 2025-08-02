using Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IPersonelUserCoverLetterDal : IEntityRepository<PersonelUserCoverLetter>
    {
        Task<List<PersonelUserCoverLetterDTO>> GetAllDTO();
        Task<List<PersonelUserCoverLetterDTO>> GetDeletedAllDTO();
    }
}
