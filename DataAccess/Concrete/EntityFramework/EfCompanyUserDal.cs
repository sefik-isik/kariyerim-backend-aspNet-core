using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Business.Constans;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyUserDal : EfEntityRepositoryBase<CompanyUser, KariyerimContext>, ICompanyUserDal
    {
        ICompanyUserAdvertDal _companyUserAdvertDal;

        public EfCompanyUserDal(ICompanyUserAdvertDal companyUserAdvertDal)
        {
            _companyUserAdvertDal = companyUserAdvertDal;
        }

        public async Task TerminateSubDatas(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                List<CompanyUserAdvert> adverts = await GetAllAdvertCityUserId(id);
                if (adverts != null && adverts.Count > 0)
                {
                    foreach (var advert in adverts)
                    {
                       await _companyUserAdvertDal.TerminateSubDatas(advert.Id);
                    }
                }

                var companyUserAddressesDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [CompanyUserAddresses] WHERE [CompanyUserId] = {id}");
                var companyUserAdvertJobDescriptionsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [CompanyUserAdvertJobDescriptions] WHERE [CompanyUserId] = {id}");
                var companyUserDepartmentsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [CompanyUserDepartments] WHERE [CompanyUserId] = {id}");
                var companyUserFilesDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [CompanyUserFiles] WHERE [CompanyUserId] = {id}");
                var companyUserImagesDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [CompanyUserImages] WHERE [CompanyUserId] = {id}");
                var personelUserAdvertApplicationsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUserAdvertApplications] WHERE [CompanyUserId] = {id}");
                var personelUserAdvertFollowsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUserAdvertFollows] WHERE [CompanyUserId] = {id}");
                var personelUserFollowCompanyUsersDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUserFollowCompanyUsers] WHERE [CompanyUserId] = {id}");
                var companyUserAdvertsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [CompanyUserAdverts] WHERE [CompanyUserId] = {id}");
            }
        }

            private async Task<List<CompanyUserAdvert>> GetAllAdvertCityUserId(string id)
            {
                using (KariyerimContext context = new KariyerimContext())
                {
                    var adverts = from companyUserAdverts in context.CompanyUserAdverts
                              join companyUsers in context.CompanyUsers on companyUserAdverts.CompanyUserId equals companyUsers.Id
                              where companyUserAdverts.CompanyUserId == id
                              select new CompanyUserAdvert
                              {
                                  Id = companyUserAdverts.Id,
                              };
                    return await adverts.ToListAsync();
                }
            }
        
        public async Task<List<CompanyUserDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUsers in context.CompanyUsers
                             join users in context.Users on companyUsers.UserId equals users.Id
                             join sectors in context.Sectors on companyUsers.SectorId equals sectors.Id
                             join cities in context.Cities on companyUsers.TaxCityId equals cities.Id
                             join taxOffices in context.TaxOffices on companyUsers.TaxOfficeId equals taxOffices.Id
                             join counts in context.Counts on companyUsers.WorkerCountId equals counts.Id

                             where users.Code == UserCodes.CompanyUserCode &&
                                    companyUsers.DeletedDate == null &&
                                    users.DeletedDate == null

                             select new CompanyUserDTO
                             {
                                 Id = companyUsers.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 About = companyUsers.About,
                                 Clarification = companyUsers.Clarification,
                                 WorkerCountId = companyUsers.WorkerCountId,
                                 WorkerCountValue = counts.CountValue,
                                 YearOfEstablishment = companyUsers.YearOfEstablishment,
                                 WebAddress = companyUsers.WebAddress,
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
                return await result.ToListAsync();
            }
        }

        public async Task<List<CompanyUserDTO>> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUsers in context.CompanyUsers
                             join users in context.Users on companyUsers.UserId equals users.Id
                             join sectors in context.Sectors on companyUsers.SectorId equals sectors.Id
                             join cities in context.Cities on companyUsers.TaxCityId equals cities.Id
                             join taxOffices in context.TaxOffices on companyUsers.TaxOfficeId equals taxOffices.Id
                             join counts in context.Counts on companyUsers.WorkerCountId equals counts.Id

                             where users.Code == UserCodes.CompanyUserCode &&
                                    companyUsers.DeletedDate != null && users.DeletedDate == null

                             select new CompanyUserDTO
                             {
                                 Id = companyUsers.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 About = companyUsers.About,
                                 Clarification = companyUsers.Clarification,
                                 WorkerCountId = companyUsers.WorkerCountId,
                                 WorkerCountValue = counts.CountValue,
                                 YearOfEstablishment = companyUsers.YearOfEstablishment,
                                 WebAddress = companyUsers.WebAddress,
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
                return await result.ToListAsync();
            }
        }
    }
}

