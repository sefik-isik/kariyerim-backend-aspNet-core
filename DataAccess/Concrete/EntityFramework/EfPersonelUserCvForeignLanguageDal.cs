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
    public class EfPersonelUserCvForeignLanguageDal : EfEntityRepositoryBase<PersonelUserCvForeignLanguage, KariyerimContext>, IPersonelUserCvForeignLanguageDal
    {
        public List<PersonelUserCvForeignLanguageDTO> GetPersonelUserCvForeignLanguageDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from cvforeignLanguages in context.PersonelUserCvForeignLanguages
                             join cvs in context.Cvs on cvforeignLanguages.CvId equals cvs.Id
                             join personelUsers in context.PersonelUsers on cvs.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join languages in context.Languages on cvforeignLanguages.LanguageId equals languages.Id
                             join languageLevels in context.LanguageLevels on cvforeignLanguages.LanguageLevelId equals languageLevels.Id

                             where cvforeignLanguages.DeletedDate==null
                             select new PersonelUserCvForeignLanguageDTO
                             {
                                 Id = cvforeignLanguages.Id,
                                 PersonelUserId = personelUsers.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 CvId = cvforeignLanguages.CvId,
                                 CvName = cvs.CvName,
                                 LanguageId = languages.Id,
                                 LanguageName = languages.LanguageName,
                                 LanguageLevelId = languageLevels.Id,
                                 LanguageLevelName = languageLevels.LevelTitle,
                                 Level = languageLevels.Level,
                                 LevelTitle = languageLevels.LevelTitle,
                                 LevelDescription = languageLevels.LevelDescription,
                                 CreatedDate = languageLevels.CreatedDate,
                                 UpdatedDate = languageLevels.UpdatedDate,
                                 DeletedDate = languageLevels.DeletedDate,
                                 
                             };
                return result.ToList();

            }
        }

        public List<PersonelUserCvForeignLanguageDTO> GetPersonelUserCvForeignLanguageDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from cvforeignLanguages in context.PersonelUserCvForeignLanguages
                             join cvs in context.Cvs on cvforeignLanguages.CvId equals cvs.Id
                             join personelUsers in context.PersonelUsers on cvs.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join languages in context.Languages on cvforeignLanguages.LanguageId equals languages.Id
                             join languageLevels in context.LanguageLevels on cvforeignLanguages.LanguageLevelId equals languageLevels.Id

                             where cvforeignLanguages.DeletedDate != null
                             select new PersonelUserCvForeignLanguageDTO
                             {
                                 Id = cvforeignLanguages.Id,
                                 PersonelUserId = personelUsers.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 CvId = cvforeignLanguages.CvId,
                                 CvName = cvs.CvName,
                                 LanguageId = languages.Id,
                                 LanguageName = languages.LanguageName,
                                 LanguageLevelId = languageLevels.Id,
                                 LanguageLevelName = languageLevels.LevelTitle,
                                 Level = languageLevels.Level,
                                 LevelTitle = languageLevels.LevelTitle,
                                 LevelDescription = languageLevels.LevelDescription,
                                 CreatedDate = languageLevels.CreatedDate,
                                 UpdatedDate = languageLevels.UpdatedDate,
                                 DeletedDate = languageLevels.DeletedDate,

                             };
                return result.ToList();

            }
        }
    }
}
