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
    public class EfPersonelUserAboutDal : EfEntityRepositoryBase<PersonelUserAbout, KariyerimContext>, IPersonelUserAboutDal
    {
        public List<PersonelUserAboutDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAbouts in context.PersonelUserAbouts
                             join personelUsers in context.PersonelUsers on personelUserAbouts.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUserAbouts.UserId equals users.Id
                             join driverLicences in context.DriverLicences on personelUserAbouts.DriverLicenceId equals driverLicences.Id
                             join genders in context.Genders on personelUserAbouts.GenderId equals genders.Id

                             select new PersonelUserAboutDTO
                             {
                                 Id = personelUserAbouts.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 PersonelUserId = personelUsers.Id,
                                 IdentityNumber = personelUsers.IdentityNumber,
                                 NationalStatus = personelUserAbouts.NationalStatus,
                                 GenderId =genders.Id,
                                 GenderName = genders.GenderName,
                                 DriverLicenceId = personelUserAbouts.DriverLicenceId,
                                 DriverLicenceName = driverLicences.LicenceName,
                                 MilitaryStatus = personelUserAbouts.MilitaryStatus,
                                 RetirementStatus = personelUserAbouts.RetirementStatus,
                                 CreatedDate = personelUserAbouts.CreatedDate,
                                 UpdatedDate = personelUserAbouts.UpdatedDate,
                                 DeletedDate = personelUserAbouts.DeletedDate,
                             };
                return result.ToList();
            }
        }

        
    }
}
