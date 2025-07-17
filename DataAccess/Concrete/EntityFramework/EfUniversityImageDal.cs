using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUniversityImageDal : EfEntityRepositoryBase<UniversityImage, KariyerimContext>, IUniversityImageDal
    {
        public async Task UpdateMainImage(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var universityIdMainImageUpdated = await context.Database.ExecuteSqlAsync($"UPDATE [UniversityImages] SET [isMainImage]=false  WHERE [UniversityId] = {id}");
            }
        }

        public async Task UpdateLogoImage(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var universityLogoImageUpdated = await context.Database.ExecuteSqlAsync($"UPDATE [UniversityImages] SET [isLogo]=false  WHERE [UniversityId] = {id}");
            }
        }
    }
}
