using Core.DataAccess.EntityFramework;
using Core.Utilities.Business.Constans;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyUserImageDal : EfEntityRepositoryBase<CompanyUserImage, KariyerimContext>, ICompanyUserImageDal
    {
        public async Task UpdateMainImage(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var companyUserMainImageUpdated = await context.Database.ExecuteSqlAsync($"UPDATE [CompanyUserImages] SET [IsMainImage]='false'  WHERE [CompanyUserId] = {id}");

                
            }
        }

        public async Task UpdateLogoImage(string id, string imageOwnName, string imagePath, string imageName)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var companyUserLogoImageUpdated = await context.Database.ExecuteSqlAsync($"UPDATE [CompanyUserImages] SET [IsLogo]='false'  WHERE [CompanyUserId] = {id}");
                var companyUserAdvertUpdated = await context.Database
 .ExecuteSqlAsync($"UPDATE [CompanyUserAdverts] SET [ImageOwnName]={imageOwnName}, [ImagePath]={imagePath}, [ImageName]={imageName}  WHERE [CompanyUserId] = {id}");
                var companyUserUpdated = await context.Database
 .ExecuteSqlAsync($"UPDATE [CompanyUsers] SET [ImageOwnName]={imageOwnName}, [ImagePath]={imagePath}, [ImageName]={imageName}  WHERE [Id] = {id}");
            }
        }

        public async Task<List<CompanyUserImageDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserImages in context.CompanyUserImages
                             join companyUsers in context.CompanyUsers on companyUserImages.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id

                             where users.Code == UserCodes.CompanyUserCode &&
                             companyUserImages.DeletedDate == null && users.DeletedDate == null && companyUsers.DeletedDate == null

                             select new CompanyUserImageDTO
                             {
                                 Id = companyUserImages.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 ImageOwnName = companyUserImages.ImageOwnName,
                                 ImageName = companyUserImages.ImageName,
                                 ImagePath = companyUserImages.ImagePath,
                                 IsMainImage = companyUserImages.IsMainImage,
                                 IsLogo = companyUserImages.IsLogo,
                                 CreatedDate = companyUserImages.CreatedDate,
                                 UpdatedDate = companyUserImages.UpdatedDate,
                                 DeletedDate = companyUserImages.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<CompanyUserImageDTO>> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserImages in context.CompanyUserImages
                             join companyUsers in context.CompanyUsers on companyUserImages.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id

                             where users.Code == UserCodes.CompanyUserCode &&
                             companyUserImages.DeletedDate != null && users.DeletedDate == null && companyUsers.DeletedDate == null

                             select new CompanyUserImageDTO
                             {
                                 Id = companyUserImages.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 ImageOwnName = companyUserImages.ImageOwnName,
                                 ImageName = companyUserImages.ImageName,
                                 ImagePath = companyUserImages.ImagePath,
                                 IsMainImage = companyUserImages.IsMainImage,
                                 IsLogo = companyUserImages.IsLogo,
                                 CreatedDate = companyUserImages.CreatedDate,
                                 UpdatedDate = companyUserImages.UpdatedDate,
                                 DeletedDate = companyUserImages.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<CompanyUserImage>> GetCompanyUserMainImage(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserImages in context.CompanyUserImages


                             where companyUserImages.CompanyUserId == id && companyUserImages.DeletedDate == null && companyUserImages.IsMainImage == true

                             select new CompanyUserImage
                             {
                                 Id = companyUserImages.Id,
                                 CompanyUserId = companyUserImages.CompanyUserId,
                                 ImagePath = companyUserImages.ImagePath,
                                 ImageName = companyUserImages.ImageName,
                                 ImageOwnName = companyUserImages.ImageOwnName,
                                 IsMainImage = companyUserImages.IsMainImage,
                                 IsLogo = companyUserImages.IsLogo,
                                 CreatedDate = companyUserImages.CreatedDate,
                                 UpdatedDate = companyUserImages.UpdatedDate,
                                 DeletedDate = companyUserImages.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<CompanyUserImage>> GetCompanyUserLogoImage(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserImages in context.CompanyUserImages


                             where companyUserImages.CompanyUserId == id && companyUserImages.DeletedDate == null && companyUserImages.IsLogo == true

                             select new CompanyUserImage
                             {
                                 Id = companyUserImages.Id,
                                 CompanyUserId = companyUserImages.CompanyUserId,
                                 ImagePath = companyUserImages.ImagePath,
                                 ImageName = companyUserImages.ImageName,
                                 ImageOwnName = companyUserImages.ImageOwnName,
                                 IsMainImage = companyUserImages.IsMainImage,
                                 IsLogo = companyUserImages.IsLogo,
                                 CreatedDate = companyUserImages.CreatedDate,
                                 UpdatedDate = companyUserImages.UpdatedDate,
                                 DeletedDate = companyUserImages.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

    }
}
