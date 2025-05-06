using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Business.Constans;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelUserDal : EfEntityRepositoryBase<PersonelUser, KariyerimContext>, IPersonelUserDal
    {
        public List<PersonelUserDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUsers in context.PersonelUsers
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join driverLicences in context.DriverLicences on personelUsers.DriverLicenceId equals driverLicences.Id
                             join licenceDegrees in context.LicenceDegrees on personelUsers.LicenceDegreeId equals licenceDegrees.Id
                             join cities in context.Cities on personelUsers.BirthPlaceId equals cities.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUsers.DeletedDate == null 

                             select new PersonelUserDTO
                             {
                                 Id = personelUsers.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 IdentityNumber = personelUsers.IdentityNumber,
                                 Gender=personelUsers.Gender,
                                 LicenceDegreeId=personelUsers.LicenceDegreeId,
                                 LicenceDegreeName=licenceDegrees.LicenceDegreeName,
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

       public List<PersonelUserDTO> GetAllDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUsers in context.PersonelUsers
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join driverLicences in context.DriverLicences on personelUsers.DriverLicenceId equals driverLicences.Id
                             join licenceDegrees in context.LicenceDegrees on personelUsers.LicenceDegreeId equals licenceDegrees.Id
                             join cities in context.Cities on personelUsers.BirthPlaceId equals cities.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUsers.DeletedDate != null

                             select new PersonelUserDTO
                             {
                                 Id = personelUsers.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 IdentityNumber = personelUsers.IdentityNumber,
                                 Gender=personelUsers.Gender,
                                 LicenceDegreeId=personelUsers.LicenceDegreeId,
                                 LicenceDegreeName=licenceDegrees.LicenceDegreeName,
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
