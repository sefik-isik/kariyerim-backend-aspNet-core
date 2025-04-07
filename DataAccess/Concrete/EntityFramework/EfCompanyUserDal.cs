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
                                 CompanyUserName = companyUsers.CompanyUserName,
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
                var result = from companyUsers in context.CompanyUsers
                             join users in context.Users on companyUsers.UserId equals users.Id
                             join sectors in context.Sectors on companyUsers.SectorId equals sectors.Id
                             join cities in context.Cities on companyUsers.TaxCityId equals cities.Id
                             join taxOffices in context.TaxOffices on companyUsers.TaxOfficeId equals taxOffices.Id
                             where companyUsers.DeletedDate != null
                             select new CompanyUserDTO
                             {
                                 Id = companyUsers.Id,
                                 UserId = users.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
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
    }
}

