using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Business.Constans;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelUserDal : EfEntityRepositoryBase<PersonelUser, KariyerimContext>, IPersonelUserDal
    {
        IPersonelUserCvDal _personelUserCvDal;

        public EfPersonelUserDal(IPersonelUserCvDal personelUserCvDal)
        {
            _personelUserCvDal = personelUserCvDal;
        }

        public async Task TerminateSubDatas(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                List<PersonelUserCv> cvs = GetAllCvByPersonelUserId(id);
                if (cvs != null && cvs.Count>0)
                {
                    foreach (var cv in cvs)
                    {
                        _personelUserCvDal.TerminateSubDatas(cv.Id);
                    }
                }

                var personelUserAddressesDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUserAddresses] WHERE [PersonelUserId] = {id}");
                var personelUserCoverLettersDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUserCoverLetters] WHERE [PersonelUserId] = {id}");
                var personelUserFilesDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUserFiles] WHERE [PersonelUserId] = {id}");
                var personelUserImagesDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUserImages] WHERE [PersonelUserId] = {id}");
                var personelUserAdvertApplicationsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUserAdvertApplications] WHERE [PersonelUserId] = {id}");
                var personelUserAdvertFollowsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUserAdvertFollows] WHERE [PersonelUserId] = {id}");
                var personelUserFollowCompanyUsersDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUserFollowCompanyUsers] WHERE [PersonelUserId] = {id}");
                var personelUserCvsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUserCvs] WHERE [PersonelUserId] = {id}");
            }
        }

        private List<PersonelUserCv> GetAllCvByPersonelUserId(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var cvs = from personelUserCvs in context.PersonelUserCvs
                          join personelUsers in context.PersonelUsers on personelUserCvs.PersonelUserId equals personelUsers.Id
                          where personelUserCvs.PersonelUserId == id
                          select new PersonelUserCv
                          {
                              Id = personelUserCvs.Id,
                          };
                return cvs.ToList();
            }
        }

        public List<PersonelUserDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUsers in context.PersonelUsers
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join driverLicences in context.DriverLicences on personelUsers.DriverLicenceId equals driverLicences.Id
                             join licenceDegrees in context.LicenseDegrees on personelUsers.LicenseDegreeId equals licenceDegrees.Id
                             join cities in context.Cities on personelUsers.BirthPlaceId equals cities.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUsers.DeletedDate == null && users.DeletedDate == null

                             select new PersonelUserDTO
                             {
                                 Id = personelUsers.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 IdentityNumber = personelUsers.IdentityNumber,
                                 Gender=personelUsers.Gender,
                                 LicenseDegreeId=personelUsers.LicenseDegreeId,
                                 LicenseDegreeName=licenceDegrees.LicenseDegreeName,
                                 DriverLicenceId = driverLicences.Id,
                                 DriverLicenceName = driverLicences.DriverLicenceName,
                                 MilitaryStatus = personelUsers.MilitaryStatus,
                                 NationalStatus = personelUsers.NationalStatus,
                                 RetirementStatus = personelUsers.RetirementStatus,
                                 BirthPlaceId = personelUsers.BirthPlaceId,
                                 BirthPlaceName = cities.CityName,
                                 DateOfBirth = personelUsers.DateOfBirth,
                                 CreatedDate = personelUsers.CreatedDate,
                                 UpdatedDate = personelUsers.UpdatedDate,
                                 DeletedDate = personelUsers.DeletedDate,
                                 
                             };
                return result.ToList();
            }
        }

       public List<PersonelUserDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUsers in context.PersonelUsers
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join driverLicences in context.DriverLicences on personelUsers.DriverLicenceId equals driverLicences.Id
                             join licenceDegrees in context.LicenseDegrees on personelUsers.LicenseDegreeId equals licenceDegrees.Id
                             join cities in context.Cities on personelUsers.BirthPlaceId equals cities.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUsers.DeletedDate != null && users.DeletedDate == null

                             select new PersonelUserDTO
                             {
                                 Id = personelUsers.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 IdentityNumber = personelUsers.IdentityNumber,
                                 Gender = personelUsers.Gender,
                                 LicenseDegreeId = personelUsers.LicenseDegreeId,
                                 LicenseDegreeName = licenceDegrees.LicenseDegreeName,
                                 DriverLicenceId = driverLicences.Id,
                                 DriverLicenceName = driverLicences.DriverLicenceName,
                                 MilitaryStatus = personelUsers.MilitaryStatus,
                                 NationalStatus = personelUsers.NationalStatus,
                                 RetirementStatus = personelUsers.RetirementStatus,
                                 BirthPlaceId = personelUsers.BirthPlaceId,
                                 BirthPlaceName = cities.CityName,
                                 DateOfBirth = personelUsers.DateOfBirth,
                                 CreatedDate = personelUsers.CreatedDate,
                                 UpdatedDate = personelUsers.UpdatedDate,
                                 DeletedDate = personelUsers.DeletedDate,

                             };
                return result.ToList();
            }
        }
    }
}
