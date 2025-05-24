using Core.DataAccess.EntityFramework;
using Core.Utilities.Business.Constans;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelUserCoverLetterDal : EfEntityRepositoryBase<PersonelUserCoverLetter, KariyerimContext>,IPersonelUserCoverLetterDal
    {
        public List<PersonelUserCoverLetterDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCoverLetters in context.PersonelUserCoverLetters
                             join personelUsers in context.PersonelUsers on personelUserCoverLetters.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id


                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCoverLetters.DeletedDate == null && users.DeletedDate == null && personelUsers.DeletedDate == null

                             select new PersonelUserCoverLetterDTO
                             {
                                 Id = personelUserCoverLetters.Id,
                                 PersonelUserId = personelUsers.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 Title = personelUserCoverLetters.Title,
                                 Description = personelUserCoverLetters.Description,
                                 CreatedDate = personelUserCoverLetters.CreatedDate,
                                 UpdatedDate = personelUserCoverLetters.UpdatedDate,
                                 DeletedDate = personelUserCoverLetters.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<PersonelUserCoverLetterDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCoverLetters in context.PersonelUserCoverLetters
                             join personelUsers in context.PersonelUsers on personelUserCoverLetters.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id


                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCoverLetters.DeletedDate != null && users.DeletedDate == null && personelUsers.DeletedDate == null

                             select new PersonelUserCoverLetterDTO
                             {
                                 Id = personelUserCoverLetters.Id,
                                 PersonelUserId = personelUsers.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 Title = personelUserCoverLetters.Title,
                                 Description = personelUserCoverLetters.Description,
                                 CreatedDate = personelUserCoverLetters.CreatedDate,
                                 UpdatedDate = personelUserCoverLetters.UpdatedDate,
                                 DeletedDate = personelUserCoverLetters.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
