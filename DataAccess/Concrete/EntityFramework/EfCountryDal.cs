using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCountryDal : EfEntityRepositoryBase<Country, KariyerimContext>, ICountryDal
    {
        public async Task TerminateSubDatas(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var citiesDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [Cities] WHERE [CountryId] = {id}");
                var regionsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [Regions] WHERE [CountryId] = {id}");
            }
        }
    }
}
