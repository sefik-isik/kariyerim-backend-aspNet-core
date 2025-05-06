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
        List<CompanyUserDTO> GetAllDTO();
        List<CompanyUserDTO> GetAllDeletedDTO();
    }
}
