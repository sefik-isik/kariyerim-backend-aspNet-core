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
    public class EfPersonelUserCvSummaryDal : EfEntityRepositoryBase<PersonelUserCvSummary, KariyerimContext>, IPersonelUserCvSummaryDal
    {
        public List<PersonelUserCvSummaryDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCvSummaries in context.PersonelUserCvSummaries
                             join personelUserCv in context.PersonelUserCvs on personelUserCvSummaries.CvId equals personelUserCv.Id
                             join personelUsers in context.PersonelUsers on personelUserCvSummaries.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCvSummaries.DeletedDate == null && users.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCv.DeletedDate == null

                             select new PersonelUserCvSummaryDTO
                             {
                                 Id = personelUserCvSummaries.Id,
                                 UserId = users.Id,
                                 PersonelUserId = personelUsers.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CvId = personelUserCv.Id,
                                 CvName = personelUserCv.CvName,
                                 CvSummaryTitle = personelUserCvSummaries.CvSummaryTitle,
                                 CvSummaryDescription = personelUserCvSummaries.CvSummaryDescription,
                                 CreatedDate = personelUserCvSummaries.CreatedDate,
                                 UpdatedDate = personelUserCvSummaries.UpdatedDate,
                                 DeletedDate = personelUserCvSummaries.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<PersonelUserCvSummaryDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCvSummaries in context.PersonelUserCvSummaries
                             join personelUserCv in context.PersonelUserCvs on personelUserCvSummaries.CvId equals personelUserCv.Id
                             join personelUsers in context.PersonelUsers on personelUserCvSummaries.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCvSummaries.DeletedDate != null && users.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCv.DeletedDate == null

                             select new PersonelUserCvSummaryDTO
                             {
                                 Id = personelUserCvSummaries.Id,
                                 UserId = users.Id,
                                 PersonelUserId = personelUsers.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CvId = personelUserCv.Id,
                                 CvName = personelUserCv.CvName,
                                 CvSummaryTitle = personelUserCvSummaries.CvSummaryTitle,
                                 CvSummaryDescription = personelUserCvSummaries.CvSummaryDescription,
                                 CreatedDate = personelUserCvSummaries.CreatedDate,
                                 UpdatedDate = personelUserCvSummaries.UpdatedDate,
                                 DeletedDate = personelUserCvSummaries.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
