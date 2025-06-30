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
    public interface ICompanyUserAdvertDal : IEntityRepository<CompanyUserAdvert>
    {
        Task TerminateSubDatas(string id);
        List<CompanyUserAdvertDTO> GetAllDTO();
        List<CompanyUserAdvertDTO> GetDeletedAllDTO();
    }
}
