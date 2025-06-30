using Core.Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICountryDal : IEntityRepository<Country>
    {
        Task TerminateSubDatas(string id);
    }
}
