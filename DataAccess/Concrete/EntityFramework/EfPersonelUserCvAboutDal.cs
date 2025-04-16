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
        public List<PersonelUserCvAboutDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCvAbouts in context.PersonelUserCvAbouts
                             join personelUsers in context.PersonelUsers on personelUserCvAbouts.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUserCvAbouts.UserId equals users.Id
                             join driverLicences in context.DriverLicenses on personelUserCvAbouts.DriverLicenseId equals driverLicences.Id

                             select new PersonelUserCvAboutDTO
                             {
                                 Id = personelUserCvAbouts.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 PersonelUserId =personelUsers.Id,
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

        
    }
}
