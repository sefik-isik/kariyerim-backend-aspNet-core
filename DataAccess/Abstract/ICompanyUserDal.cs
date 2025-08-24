using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Core.Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICompanyUserDal : IEntityRepository<CompanyUser>
    {
        Task TerminateSubDatas(string id);
        Task<List<CompanyUserDTO>> GetAllDTO();
        Task<List<CompanyUserDTO>> GetDeletedAllDTO();
        Task<List<CompanyUserDTO>> GetAllForAllUserDTO();
    }
}
