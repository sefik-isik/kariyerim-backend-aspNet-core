using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfPersonelUserCvAboutDal : EfEntityRepositoryBase<PersonelUserCvAbout, KariyerimContext>, IPersonelUserCvAboutDal
    {
        public List<PersonelUserCvAboutDTO> GetPersonelUserCvAboutDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCvAbouts in context.PersonelUserCvAbouts
                             join personelUsers in context.PersonelUsers on personelUserCvAbouts.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUserCvAbouts.UserId equals users.Id
                             join driverLicences in context.DriverLicenses on personelUserCvAbouts.DriverLicenseId equals driverLicences.Id
                             
                             where personelUserCvAbouts.DeletedDate==null
                             select new PersonelUserCvAboutDTO
                             {
                                 Id = personelUserCvAbouts.Id,
                                 UserId=users.Id,
                                 PersonelUserId=personelUsers.Id,
                                 CvId = personelUserCvAbouts.CvId,
                                 NationalStatus = personelUserCvAbouts.NationalStatus,
                                 DriverLicenseId = personelUserCvAbouts.DriverLicenseId,
                                 DriverLicenseName = driverLicences.LicenseName,
                                 MilitaryStatus = personelUserCvAbouts.MilitaryStatus,
                                 RetirementStatus = personelUserCvAbouts.RetirementStatus,
                                 CreatedDate = personelUserCvAbouts.CreatedDate,
                                 UpdatedDate = personelUserCvAbouts.UpdatedDate,
                                 DeletedDate = personelUserCvAbouts.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<PersonelUserCvAboutDTO> GetPersonelUserCvAboutDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from cvAbouts in context.PersonelUserCvAbouts
                             join personelUsers in context.PersonelUsers on cvAbouts.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join driverLicences in context.DriverLicenses on cvAbouts.DriverLicenseId equals driverLicences.Id

                             where cvAbouts.DeletedDate != null
                             select new PersonelUserCvAboutDTO
                             {
                                 Id = cvAbouts.Id,
                                 UserId = users.Id,
                                 PersonelUserId = personelUsers.Id,
                                 CvId = cvAbouts.CvId,
                                 NationalStatus = cvAbouts.NationalStatus,
                                 DriverLicenseId = cvAbouts.DriverLicenseId,
                                 DriverLicenseName = driverLicences.LicenseName,
                                 MilitaryStatus = cvAbouts.MilitaryStatus,
                                 RetirementStatus = cvAbouts.RetirementStatus,
                                 CreatedDate = cvAbouts.CreatedDate,
                                 UpdatedDate = cvAbouts.UpdatedDate,
                                 DeletedDate = cvAbouts.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
