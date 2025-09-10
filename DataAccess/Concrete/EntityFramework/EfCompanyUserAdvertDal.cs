using Core.DataAccess.EntityFramework;
using Core.Utilities.Business.Constans;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyUserAdvertDal : EfEntityRepositoryBase<CompanyUserAdvert, KariyerimContext>, ICompanyUserAdvertDal
    {
        public async Task TerminateSubDatas(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var companyUserAdvertCitiesDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [CompanyUserAdvertCities] WHERE [AdvertId] = {id}");
                var companyUserAdvertJobDescriptionsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [CompanyUserAdvertJobDescriptions] WHERE [AdvertId] = {id}");
            }
        }
        public async Task<List<CompanyUserAdvertDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserAdvert in context.CompanyUserAdverts
                             join companyUsers in context.CompanyUsers on companyUserAdvert.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUserAdvert.UserId equals users.Id
                             join workAreas in context.WorkAreas on companyUserAdvert.WorkAreaId equals workAreas.Id
                             join workingMethods in context.WorkingMethods on companyUserAdvert.WorkingMethodId equals workingMethods.Id
                             join experiences in context.Experiences on companyUserAdvert.ExperienceId equals experiences.Id
                             join companyUserDepartments in context.CompanyUserDepartments on companyUserAdvert.DepartmentId equals companyUserDepartments.Id
                             join licenseDegrees in context.LicenseDegrees on companyUserAdvert.LicenseDegreeId equals licenseDegrees.Id
                             join positions in context.Positions on companyUserAdvert.PositionId equals positions.Id
                             join positionLevels in context.PositionLevels on companyUserAdvert.PositionLevelId equals positionLevels.Id
                             join languages in context.Languages on companyUserAdvert.LanguageId equals languages.Id
                             join languageLevels in context.LanguageLevels on companyUserAdvert.LanguageLevelId equals languageLevels.Id
                             join driverLicences in context.DriverLicences on companyUserAdvert.DriverLicenceId equals driverLicences.Id
                             join countries in context.Countries on companyUserAdvert.CountryId equals countries.Id
                             join cities in context.Cities on companyUserAdvert.CityId equals cities.Id
                             join regions in context.Regions on companyUserAdvert.RegionId equals regions.Id
                             join sectors in context.Sectors on companyUserAdvert.SectorId equals sectors.Id

                             where users.Code == UserCodes.CompanyUserCode && companyUserAdvert.DeletedDate == null && users.DeletedDate == null  && companyUsers.DeletedDate == null && workAreas.DeletedDate == null
                             && workingMethods.DeletedDate == null && experiences.DeletedDate == null 
                             && companyUserDepartments.DeletedDate == null && licenseDegrees.DeletedDate == null
                             && countries.DeletedDate==null && cities.DeletedDate == null && regions.DeletedDate == null && sectors.DeletedDate == null

                             select new CompanyUserAdvertDTO
                             {
                                 Id = companyUserAdvert.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 AdvertName = companyUserAdvert.AdvertName,
                                 ImageName = companyUserAdvert.ImageName,
                                 ImagePath = companyUserAdvert.ImagePath,
                                 ImageOwnName = companyUserAdvert.ImageOwnName,
                                 WorkAreaId = companyUserAdvert.WorkAreaId,
                                 WorkAreaName = workAreas.AreaName,
                                 WorkingMethodId = companyUserAdvert.WorkingMethodId,
                                 WorkingMethodName = workingMethods.MethodName,
                                 ExperienceId = companyUserAdvert.ExperienceId,
                                 ExperienceName = experiences.ExperienceName,
                                 DepartmentId = companyUserAdvert.DepartmentId,
                                 DepartmentName = companyUserDepartments.DepartmentName,
                                 LicenseDegreeId = companyUserAdvert.LicenseDegreeId,
                                 LicenseDegreeName = licenseDegrees.LicenseDegreeName,
                                 PositionId = companyUserAdvert.PositionId,
                                 PositionName = positions.PositionName,
                                 PositionLevelId = companyUserAdvert.PositionLevelId,
                                 PositionLevelName = positionLevels.PositionLevelName,
                                 MilitaryStatus = companyUserAdvert.MilitaryStatus,
                                 LanguageId = companyUserAdvert.LanguageId,
                                 LanguageName = languages.LanguageName,
                                 LanguageLevelId = companyUserAdvert.LanguageLevelId,
                                 LanguageLevelName = languageLevels.LevelTitle,
                                 DriverLicenceId = companyUserAdvert.DriverLicenceId,
                                 DriverLicenceName = driverLicences.DriverLicenceName,
                                 CountryId = companyUserAdvert.CountryId,
                                 CountryName=countries.CountryName,
                                 CityId = companyUserAdvert.CityId,
                                 CityName=cities.CityName,
                                 RegionId = companyUserAdvert.RegionId,
                                 RegionName=regions.RegionName,
                                 SectorId = companyUserAdvert.SectorId,
                                 SectorName=sectors.SectorName,
                                 CreatedDate = companyUserAdvert.CreatedDate,
                                 UpdatedDate = companyUserAdvert.UpdatedDate,
                                 DeletedDate = companyUserAdvert.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<CompanyUserAdvertDTO>> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserAdvert in context.CompanyUserAdverts
                             join companyUsers in context.CompanyUsers on companyUserAdvert.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUserAdvert.UserId equals users.Id
                             join workAreas in context.WorkAreas on companyUserAdvert.WorkAreaId equals workAreas.Id
                             join workingMethods in context.WorkingMethods on companyUserAdvert.WorkingMethodId equals workingMethods.Id
                             join experiences in context.Experiences on companyUserAdvert.ExperienceId equals experiences.Id
                             join companyUserDepartments in context.CompanyUserDepartments on companyUserAdvert.DepartmentId equals companyUserDepartments.Id
                             join licenseDegrees in context.LicenseDegrees on companyUserAdvert.LicenseDegreeId equals licenseDegrees.Id
                             join positions in context.Positions on companyUserAdvert.PositionId equals positions.Id
                             join positionLevels in context.PositionLevels on companyUserAdvert.PositionLevelId equals positionLevels.Id
                             join languages in context.Languages on companyUserAdvert.LanguageId equals languages.Id
                             join languageLevels in context.LanguageLevels on companyUserAdvert.LanguageLevelId equals languageLevels.Id
                             join driverLicences in context.DriverLicences on companyUserAdvert.DriverLicenceId equals driverLicences.Id
                             join countries in context.Countries on companyUserAdvert.CountryId equals countries.Id
                             join cities in context.Cities on companyUserAdvert.CityId equals cities.Id
                             join regions in context.Regions on companyUserAdvert.RegionId equals regions.Id
                             join sectors in context.Sectors on companyUserAdvert.SectorId equals sectors.Id

                             where users.Code == UserCodes.CompanyUserCode && companyUserAdvert.DeletedDate != null && users.DeletedDate == null && companyUsers.DeletedDate == null && workAreas.DeletedDate == null
                             && workingMethods.DeletedDate == null && experiences.DeletedDate == null
                             && companyUserDepartments.DeletedDate == null && licenseDegrees.DeletedDate == null
                             && countries.DeletedDate == null && cities.DeletedDate == null && regions.DeletedDate == null && sectors.DeletedDate == null

                             select new CompanyUserAdvertDTO
                             {
                                 Id = companyUserAdvert.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 AdvertName = companyUserAdvert.AdvertName,
                                 ImageName = companyUserAdvert.ImageName,
                                 ImagePath = companyUserAdvert.ImagePath,
                                 ImageOwnName = companyUserAdvert.ImageOwnName,
                                 WorkAreaId = companyUserAdvert.WorkAreaId,
                                 WorkAreaName = workAreas.AreaName,
                                 WorkingMethodId = companyUserAdvert.WorkingMethodId,
                                 WorkingMethodName = workingMethods.MethodName,
                                 ExperienceId = companyUserAdvert.ExperienceId,
                                 ExperienceName = experiences.ExperienceName,
                                 DepartmentId = companyUserAdvert.DepartmentId,
                                 DepartmentName = companyUserDepartments.DepartmentName,
                                 LicenseDegreeId = companyUserAdvert.LicenseDegreeId,
                                 LicenseDegreeName = licenseDegrees.LicenseDegreeName,
                                 PositionId = companyUserAdvert.PositionId,
                                 PositionName = positions.PositionName,
                                 PositionLevelId = companyUserAdvert.PositionLevelId,
                                 PositionLevelName = positionLevels.PositionLevelName,
                                 MilitaryStatus = companyUserAdvert.MilitaryStatus,
                                 LanguageId = companyUserAdvert.LanguageId,
                                 LanguageName = languages.LanguageName,
                                 LanguageLevelId = companyUserAdvert.LanguageLevelId,
                                 LanguageLevelName = languageLevels.LevelTitle,
                                 DriverLicenceId = companyUserAdvert.DriverLicenceId,
                                 DriverLicenceName = driverLicences.DriverLicenceName,
                                 CountryId = companyUserAdvert.CountryId,
                                 CountryName = countries.CountryName,
                                 CityId = companyUserAdvert.CityId,
                                 CityName = cities.CityName,
                                 RegionId = companyUserAdvert.RegionId,
                                 RegionName = regions.RegionName,
                                 SectorId = companyUserAdvert.SectorId,
                                 SectorName = sectors.SectorName,
                                 CreatedDate = companyUserAdvert.CreatedDate,
                                 UpdatedDate = companyUserAdvert.UpdatedDate,
                                 DeletedDate = companyUserAdvert.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
