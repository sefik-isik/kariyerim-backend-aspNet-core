using Core.DataAccess.EntityFramework;
using Core.Utilities.Business.Constans;
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
        public List<PersonelUserCvWorkExperienceDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCvWorkExperiences in context.PersonelUserCvWorkExperiences
                             join personelUserCv in context.PersonelUserCvs on personelUserCvWorkExperiences.CvId equals personelUserCv.Id
                             join personelUsers in context.PersonelUsers on personelUserCv.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join sectors in context.Sectors on personelUserCvWorkExperiences.CompanySectorId equals sectors.Id
                             join companyDepartments in context.CompanyUserDepartments on personelUserCvWorkExperiences.DepartmentId equals companyDepartments.Id
                             join workingMethods in context.WorkingMethods on personelUserCvWorkExperiences.WorkingMethodId equals workingMethods.Id
                             join countries in context.Countries on personelUserCvWorkExperiences.CountryId equals countries.Id
                             join cities in context.Cities on personelUserCvWorkExperiences.CityId equals cities.Id
                             join regions in context.Regions on personelUserCvWorkExperiences.RegionId equals regions.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCvWorkExperiences.DeletedDate == null && users.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCv.DeletedDate == null

                             select new PersonelUserCvWorkExperienceDTO
                             {
                                 Id = personelUserCvWorkExperiences.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 PersonelUserId = personelUsers.Id,
                                 CvId = personelUserCv.Id,
                                 CvName = personelUserCv.CvName,
                                 Position = personelUserCvWorkExperiences.Position,
                                 CompanyName = personelUserCvWorkExperiences.CompanyName,
                                 Working = personelUserCvWorkExperiences.Working,
                                 StartDate = personelUserCvWorkExperiences.StartDate,
                                 EndDate = personelUserCvWorkExperiences.EndDate,
                                 CompanySectorId = sectors.Id,
                                 CompanySectorName = sectors.SectorName,
                                 DepartmentId = companyDepartments.Id,
                                 DepartmentName = companyDepartments.DepartmentName,
                                 WorkingMethodId = workingMethods.Id,
                                 WorkingMethodName = workingMethods.MethodName,
                                 CountryId = countries.Id,
                                 CountryName = countries.CountryName,
                                 CityId = cities.Id,
                                 CityName = cities.CityName,
                                 RegionId = regions.Id,
                                 RegionName = regions.RegionName,
                                 FoundJobInHere = personelUserCvWorkExperiences.FoundJobInHere,
                                 Detail = personelUserCvWorkExperiences.Detail,
                                 CreatedDate = personelUserCvWorkExperiences.CreatedDate,
                                 UpdatedDate = personelUserCvWorkExperiences.UpdatedDate,
                                 DeletedDate = personelUserCvWorkExperiences.DeletedDate,
                             };
                return result.ToList();

            }
        }

        public List<PersonelUserCvWorkExperienceDTO> GetAllDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCvWorkExperiences in context.PersonelUserCvWorkExperiences
                             join personelUserCv in context.PersonelUserCvs on personelUserCvWorkExperiences.CvId equals personelUserCv.Id
                             join personelUsers in context.PersonelUsers on personelUserCv.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join sectors in context.Sectors on personelUserCvWorkExperiences.CompanySectorId equals sectors.Id
                             join companyDepartments in context.CompanyUserDepartments on personelUserCvWorkExperiences.DepartmentId equals companyDepartments.Id
                             join workingMethods in context.WorkingMethods on personelUserCvWorkExperiences.WorkingMethodId equals workingMethods.Id
                             join countries in context.Countries on personelUserCvWorkExperiences.CountryId equals countries.Id
                             join cities in context.Cities on personelUserCvWorkExperiences.CityId equals cities.Id
                             join regions in context.Regions on personelUserCvWorkExperiences.RegionId equals regions.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCvWorkExperiences.DeletedDate != null && users.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCv.DeletedDate == null

                             select new PersonelUserCvWorkExperienceDTO
                             {
                                 Id = personelUserCvWorkExperiences.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 PersonelUserId = personelUsers.Id,
                                 CvId = personelUserCv.Id,
                                 CvName = personelUserCv.CvName,
                                 Position = personelUserCvWorkExperiences.Position,
                                 CompanyName = personelUserCvWorkExperiences.CompanyName,
                                 Working = personelUserCvWorkExperiences.Working,
                                 StartDate = personelUserCvWorkExperiences.StartDate,
                                 EndDate = personelUserCvWorkExperiences.EndDate,
                                 CompanySectorId = sectors.Id,
                                 CompanySectorName = sectors.SectorName,
                                 DepartmentId = companyDepartments.Id,
                                 DepartmentName = companyDepartments.DepartmentName,
                                 WorkingMethodId = workingMethods.Id,
                                 WorkingMethodName = workingMethods.MethodName,
                                 CountryId = countries.Id,
                                 CountryName = countries.CountryName,
                                 CityId = cities.Id,
                                 CityName = cities.CityName,
                                 RegionId = regions.Id,
                                 RegionName = regions.RegionName,
                                 FoundJobInHere = personelUserCvWorkExperiences.FoundJobInHere,
                                 Detail = personelUserCvWorkExperiences.Detail,
                                 CreatedDate = personelUserCvWorkExperiences.CreatedDate,
                                 UpdatedDate = personelUserCvWorkExperiences.UpdatedDate,
                                 DeletedDate = personelUserCvWorkExperiences.DeletedDate,
                             };
                return result.ToList();

            }
        }
    }
}
