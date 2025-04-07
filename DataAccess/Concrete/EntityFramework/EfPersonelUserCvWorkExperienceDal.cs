using Core.DataAccess.EntityFramework;
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
    public class EfPersonelUserCvWorkExperienceDal : EfEntityRepositoryBase<PersonelUserCvWorkExperience, KariyerimContext>, IPersonelUserCvWorkExperienceDal
    {
        public List<PersonelUserCvWorkExperienceDTO> GetPersonelUserCvWorkExperienceDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from cvWorkExperiences in context.PersonelUserCvWorkExperiences
                             join cvs in context.Cvs on cvWorkExperiences.CvId equals cvs.Id
                             join personelUsers in context.PersonelUsers on cvs.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join sectors in context.Sectors on cvWorkExperiences.CompanySectorId equals sectors.Id
                             join companyDepartments in context.CompanyUserDepartments on cvWorkExperiences.DepartmentId equals companyDepartments.Id
                             join workingMethods in context.WorkingMethods on cvWorkExperiences.WorkingMethodId equals workingMethods.Id
                             join countries in context.Countries on cvWorkExperiences.CountryId equals countries.Id
                             join cities in context.Cities on cvWorkExperiences.CityId equals cities.Id
                             join regions in context.Regions on cvWorkExperiences.RegionId equals regions.Id
                             where cvWorkExperiences.DeletedDate==null
                             select new PersonelUserCvWorkExperienceDTO
                             {
                                 Id = cvWorkExperiences.Id,
                                 UserId = users.Id,
                                 PersonelUserId = personelUsers.Id,
                                 CvId = cvs.Id,
                                 CvName = cvs.CvName,
                                 Position = cvWorkExperiences.Position,
                                 CompanyName = cvWorkExperiences.CompanyName,
                                 Working = cvWorkExperiences.Working,
                                 StartDate = cvWorkExperiences.StartDate,
                                 EndDate = cvWorkExperiences.EndDate,
                                 CompanySectorId = sectors.Id,
                                 CompanySectorName = sectors.SectorName,
                                 DepartmentId = companyDepartments.Id,
                                 DepartmentName = companyDepartments.DepartmentName,
                                 WorkingMethodId = workingMethods.Id,
                                 WorkingMethodName = workingMethods.MethodName,
                                 CountryId = countries.Id,
                                 Countryname = countries.CountryName,
                                 CityId = cities.Id,
                                 CityName = cities.CityName,
                                 RegionId = regions.Id,
                                 RegionName = regions.RegionName,
                                 Detail = cvWorkExperiences.Detail,
                                 CreatedDate = cvWorkExperiences.CreatedDate,
                                 UpdatedDate = cvWorkExperiences.UpdatedDate,
                                 DeletedDate = cvWorkExperiences.DeletedDate,
                             };
                return result.ToList();

            }
        }

        public List<PersonelUserCvWorkExperienceDTO> GetPersonelUserCvWorkExperienceDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from cvWorkExperience in context.PersonelUserCvWorkExperiences
                             join cv in context.Cvs on cvWorkExperience.CvId equals cv.Id
                             join sector in context.Sectors on cvWorkExperience.CompanySectorId equals sector.Id
                             join companyDepartment in context.CompanyUserDepartments on cvWorkExperience.DepartmentId equals companyDepartment.Id
                             join workingMethod in context.WorkingMethods on cvWorkExperience.WorkingMethodId equals workingMethod.Id
                             join country in context.Countries on cvWorkExperience.CountryId equals country.Id
                             join city in context.Cities on cvWorkExperience.CityId equals city.Id
                             join region in context.Regions on cvWorkExperience.RegionId equals region.Id
                             where cvWorkExperience.DeletedDate != null
                             select new PersonelUserCvWorkExperienceDTO
                             {
                                 Id = cvWorkExperience.Id,
                                 CvId = cv.Id,
                                 CvName = cv.CvName,
                                 Position = cvWorkExperience.Position,
                                 CompanyName = cvWorkExperience.CompanyName,
                                 Working = cvWorkExperience.Working,
                                 StartDate = cvWorkExperience.StartDate,
                                 EndDate = cvWorkExperience.EndDate,
                                 CompanySectorId=sector.Id,
                                 CompanySectorName = sector.SectorName,
                                 DepartmentId=companyDepartment.Id,
                                 DepartmentName = companyDepartment.DepartmentName,
                                 WorkingMethodId=workingMethod.Id,
                                 WorkingMethodName = workingMethod.MethodName,
                                 CountryId=country.Id,
                                 Countryname = country.CountryName,
                                 CityId=city.Id,
                                 CityName = city.CityName,
                                 RegionId = region.Id,
                                 RegionName = region.RegionName,
                                 Detail = cvWorkExperience.Detail,
                                 CreatedDate = cvWorkExperience.CreatedDate,
                                 UpdatedDate = cvWorkExperience.UpdatedDate,
                                 DeletedDate = cvWorkExperience.DeletedDate,
                             };
                return result.ToList();

            }
        }
    }
}
