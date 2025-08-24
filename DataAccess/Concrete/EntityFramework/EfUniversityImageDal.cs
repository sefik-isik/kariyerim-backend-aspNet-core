using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
                var universityIdMainImageUpdated = await context.Database.ExecuteSqlAsync($"UPDATE [UniversityImages] SET [isMainImage]='false'  WHERE [UniversityId] = {id}");
            }
        }

        public async Task UpdateLogoImage(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var universityLogoImageUpdated = await context.Database.ExecuteSqlAsync($"UPDATE [UniversityImages] SET [isLogo]='false'  WHERE [UniversityId] = {id}");
            }
        }

        public async Task<List<UniversityImage>> GetUniversityMainImage(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityImages in context.UniversityImages


                             where universityImages.UniversityId == id && universityImages.DeletedDate == null && universityImages.isMainImage == true

                             select new UniversityImage
                             {
                                 Id = universityImages.Id,
                                 UniversityId = universityImages.UniversityId,
                                 ImagePath = universityImages.ImagePath,
                                 ImageName = universityImages.ImageName,
                                 ImageOwnName = universityImages.ImageOwnName,
                                 isMainImage = universityImages.isMainImage,
                                 isLogo = universityImages.isLogo,
                                 CreatedDate = universityImages.CreatedDate,
                                 UpdatedDate = universityImages.UpdatedDate,
                                 DeletedDate = universityImages.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<UniversityImage>> GetUniversityLogoImage(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityImages in context.UniversityImages


                             where universityImages.UniversityId == id && universityImages.DeletedDate == null && universityImages.isLogo == true

                             select new UniversityImage
                             {
                                 Id = universityImages.Id,
                                 UniversityId = universityImages.UniversityId,
                                 ImagePath = universityImages.ImagePath,
                                 ImageName = universityImages.ImageName,
                                 ImageOwnName = universityImages.ImageOwnName,
                                 isMainImage = universityImages.isMainImage,
                                 isLogo = universityImages.isLogo,
                                 CreatedDate = universityImages.CreatedDate,
                                 UpdatedDate = universityImages.UpdatedDate,
                                 DeletedDate = universityImages.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
