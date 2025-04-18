using Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using DataAccess.Concrete.EntityFramework;

namespace DataAccess.Abstract
{
    public interface IPersonelUserAboutDal : IEntityRepository<PersonelUserAbout>
    {
        List<PersonelUserAboutDTO> GetAllDTO();
    }
}
