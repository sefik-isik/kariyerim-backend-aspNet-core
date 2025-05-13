using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfPersonelUserCvDal : EfEntityRepositoryBase<PersonelUserCv, KariyerimContext>, IPersonelUserCvDal
    {
        public List<PersonelUserCvDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCvs in context.PersonelUserCvs
                             join personelUsers in context.PersonelUsers on personelUserCvs.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join languages in context.Languages on personelUserCvs.LanguageId equals languages.Id
                             join languageLevels in context.LanguageLevels on personelUserCvs.LanguageLevelId equals languageLevels.Id
                             join cities in context.Cities on personelUsers.BirthPlaceId equals cities.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCvs.DeletedDate == null && users.DeletedDate == null && personelUsers.DeletedDate == null


                             select new PersonelUserCvDTO
                             {
                                 Id = personelUserCvs.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 Code = users.Code,
                                 PersonelUserId = personelUsers.Id,
                                 IdentityNumber = personelUsers.IdentityNumber,
                                 DateOfBirth = personelUsers.DateOfBirth,
                                 CvId = personelUserCvs.Id,
                                 CvName = personelUserCvs.CvName,
                                 LanguageId = languages.Id,
                                 LanguageName = languages.LanguageName,
                                 LanguageLevelId = languageLevels.Id,
                                 Level = languageLevels.Level,
                                 LevelTitle = languageLevels.LevelTitle,
                                 LevelDescription = languageLevels.LevelDescription,
                                 BirthPlaceId = cities.Id,
                                 BirthPlaceName = cities.CityName,
                                 IsPrivate = personelUserCvs.IsPrivate,
                                 CreatedDate = personelUserCvs.CreatedDate,
                                 UpdatedDate = personelUserCvs.UpdatedDate,
                                 DeletedDate = personelUserCvs.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<PersonelUserCvDTO> GetAllDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCvs in context.PersonelUserCvs
                             join personelUsers in context.PersonelUsers on personelUserCvs.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join languages in context.Languages on personelUserCvs.LanguageId equals languages.Id
                             join languageLevels in context.LanguageLevels on personelUserCvs.LanguageLevelId equals languageLevels.Id
                             join cities in context.Cities on personelUsers.BirthPlaceId equals cities.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCvs.DeletedDate != null && users.DeletedDate == null && personelUsers.DeletedDate == null


                             select new PersonelUserCvDTO
                             {
                                 Id = personelUserCvs.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 Code = users.Code,
                                 PersonelUserId = personelUsers.Id,
                                 IdentityNumber = personelUsers.IdentityNumber,
                                 DateOfBirth = personelUsers.DateOfBirth,
                                 CvId = personelUserCvs.Id,
                                 CvName = personelUserCvs.CvName,
                                 LanguageId = languages.Id,
                                 LanguageName = languages.LanguageName,
                                 LanguageLevelId = languageLevels.Id,
                                 Level = languageLevels.Level,
                                 LevelTitle = languageLevels.LevelTitle,
                                 LevelDescription = languageLevels.LevelDescription,
                                 BirthPlaceId = cities.Id,
                                 BirthPlaceName = cities.CityName,
                                 IsPrivate = personelUserCvs.IsPrivate,
                                 CreatedDate = personelUserCvs.CreatedDate,
                                 UpdatedDate = personelUserCvs.UpdatedDate,
                                 DeletedDate = personelUserCvs.DeletedDate,
                             };
                return result.ToList();
            }
        }

    }
}
