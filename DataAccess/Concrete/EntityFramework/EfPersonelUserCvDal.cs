using Core.DataAccess.EntityFramework;
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
                             join users in context.Users on personelUserCvs.UserId equals users.Id
                             join personelUsers in context.PersonelUsers on personelUserCvs.PersonelUserId equals personelUsers.Id
                             join languages in context.Languages on personelUserCvs.LanguageId equals languages.Id
                             join languageLevels in context.LanguageLevels on personelUserCvs.LanguageLevelId equals languageLevels.Id
                             join lisansDegrees in context.LicenseDegrees on personelUsers.LicenseId equals lisansDegrees.Id
                             join cities in context.Cities on personelUsers.BirthPlaceId equals cities.Id

                             select new PersonelUserCvDTO
                             {
                                 Id = personelUserCvs.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 PersonelUserId = personelUsers.Id,
                                 IdentityNumber = personelUsers.IdentityNumber,
                                 DateOfBirth = personelUsers.DateOfBirth,
                                 CvName = personelUserCvs.CvName,
                                 LanguageId = languages.Id,
                                 LanguageName = languages.LanguageName,
                                 LanguageLevelId = languageLevels.Id,
                                 Level = languageLevels.Level,
                                 LevelTitle = languageLevels.LevelTitle,
                                 LevelDescription = languageLevels.LevelDescription,
                                 LicenceId= personelUsers.LicenseId,
                                 LicenceName= lisansDegrees.LicenceName,
                                 BirthPlaceId=cities.Id,
                                 BirthPlaceName=cities.CityName,
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
