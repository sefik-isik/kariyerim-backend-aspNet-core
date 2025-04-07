using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyUserDal : EfEntityRepositoryBase<CompanyUser, KariyerimContext>, ICompanyUserDal
    {
        public List<CompanyUserDTO> GetCompanyDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUsers in context.CompanyUsers
                             join users in context.Users on companyUsers.UserId equals users.Id
                             join sectors in context.Sectors on companyUsers.SectorId equals sectors.Id
                             join cities in context.Cities on companyUsers.TaxCityId equals cities.Id
                             join taxOffices in context.TaxOffices on companyUsers.TaxOfficeId equals taxOffices.Id
                             where companyUsers.DeletedDate == null
                             select new CompanyUserDTO
                             {
                                 Id = companyUsers.Id,
                                 UserId = users.Id,
                                 CompanyName = companyUsers.CompanyName,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 SectorId = sectors.Id,
                                 SectorName = sectors.SectorName,
                                 TaxCityId = cities.Id,
                                 TaxCityName = cities.CityName,
                                 TaxOfficeId = taxOffices.Id,
                                 TaxOfficeName = taxOffices.TaxOfficeName,
                                 TaxNumber = companyUsers.TaxNumber,
                                 CreatedDate = companyUsers.CreatedDate,
                                 UpdatedDate = companyUsers.UpdatedDate,
                                 DeletedDate = companyUsers.DeletedDate,

                             };
                return result.ToList();
            }
        }

        public List<CompanyUserDTO> GetCompanyDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUser in context.CompanyUsers
                             join user in context.Users on companyUser.UserId equals user.Id
                             join sector in context.Sectors on companyUser.SectorId equals sector.Id
                             join city in context.Cities on companyUser.TaxCityId equals city.Id
                             join taxOffice in context.TaxOffices on companyUser.TaxOfficeId equals taxOffice.Id
                             where companyUser.DeletedDate != null
                             select new CompanyUserDTO
                             {
                                 Id = companyUser.Id,
                                 CompanyName = companyUser.CompanyName,
                                 UserId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 PhoneNumber = user.PhoneNumber,
                                 SectorId = sector.Id,
                                 SectorName = sector.SectorName,
                                 TaxCityId = city.Id,
                                 TaxCityName = city.CityName,
                                 TaxOfficeId = taxOffice.Id,
                                 TaxOfficeName = taxOffice.TaxOfficeName,
                                 TaxNumber = companyUser.TaxNumber,
                                 CreatedDate = companyUser.CreatedDate,
                                 UpdatedDate = companyUser.UpdatedDate,
                                 DeletedDate = companyUser.DeletedDate,

                             };
                return result.ToList();
            }
        }
    }
}

