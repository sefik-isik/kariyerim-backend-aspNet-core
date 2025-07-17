using Core.DataAccess.EntityFramework;
using Core.Utilities.Business.Constans;
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
    public class EfPersonelUserImageDal : EfEntityRepositoryBase<PersonelUserImage, KariyerimContext>, IPersonelUserImageDal
    {
        public async Task UpdateProfilImage(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var personelUserMainImageUpdated = await context.Database.ExecuteSqlAsync($"UPDATE [PersonelUserImages] SET [isProfilImage]=false  WHERE [PersonelUserId] = {id}");
            }
        }
        public List<PersonelUserImageDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserImages in context.PersonelUserImages
                             join personelUsers in context.PersonelUsers on personelUserImages.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserImages.DeletedDate == null && users.DeletedDate == null && personelUsers.DeletedDate == null

                             select new PersonelUserImageDTO
                             {
                                 Id = personelUserImages.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 PersonelUserId = personelUsers.Id,
                                 ImageOwnName = personelUserImages.ImageOwnName,
                                 ImageName = personelUserImages.ImageName,
                                 ImagePath = personelUserImages.ImagePath,
                                 IsProfilImage = personelUserImages.IsProfilImage,
                                 CreatedDate = personelUserImages.CreatedDate,
                                 UpdatedDate = personelUserImages.UpdatedDate,
                                 DeletedDate = personelUserImages.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<PersonelUserImageDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserImages in context.PersonelUserImages
                             join personelUsers in context.PersonelUsers on personelUserImages.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserImages.DeletedDate != null && users.DeletedDate == null && personelUsers.DeletedDate == null

                             select new PersonelUserImageDTO
                             {
                                 Id = personelUserImages.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 PersonelUserId = personelUsers.Id,
                                 ImageOwnName = personelUserImages.ImageOwnName,
                                 ImageName = personelUserImages.ImageName,
                                 ImagePath = personelUserImages.ImagePath,
                                 IsProfilImage = personelUserImages.IsProfilImage,
                                 CreatedDate = personelUserImages.CreatedDate,
                                 UpdatedDate = personelUserImages.UpdatedDate,
                                 DeletedDate = personelUserImages.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
