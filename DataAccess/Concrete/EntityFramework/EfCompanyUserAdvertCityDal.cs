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
    public class EfCompanyUserAdvertCityDal : EfEntityRepositoryBase<CompanyUserAdvertCity, KariyerimContext>, ICompanyUserAdvertCityDal
    {
        public async Task<List<CompanyUserAdvertCityDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserAdvertCities in context.CompanyUserAdvertCities
                             join companyUserAdverts in context.CompanyUserAdverts on companyUserAdvertCities.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on companyUserAdvertCities.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUserAdvertCities.UserId equals users.Id
                             join cities in context.Cities on companyUserAdvertCities.WorkCityId equals cities.Id

                             where users.Code == UserCodes.CompanyUserCode && companyUserAdvertCities.DeletedDate == null && users.DeletedDate == null && companyUserAdverts.DeletedDate == null && cities.DeletedDate == null 

                             select new CompanyUserAdvertCityDTO
                             {
                                 Id = companyUserAdvertCities.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUserAdvertCities.CompanyUserId,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 AdvertId = companyUserAdvertCities.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 WorkCityId = companyUserAdvertCities.WorkCityId,
                                 WorkCityName = cities.CityName,
                                 CreatedDate = companyUserAdvertCities.CreatedDate,
                                 UpdatedDate = companyUserAdvertCities.UpdatedDate,
                                 DeletedDate = companyUserAdvertCities.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<CompanyUserAdvertCityDTO>> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserAdvertCities in context.CompanyUserAdvertCities
                             join companyUserAdverts in context.CompanyUserAdverts on companyUserAdvertCities.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on companyUserAdvertCities.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUserAdvertCities.UserId equals users.Id
                             join cities in context.Cities on companyUserAdvertCities.WorkCityId equals cities.Id


                             where users.Code == UserCodes.CompanyUserCode && companyUserAdvertCities.DeletedDate != null && users.DeletedDate == null && companyUserAdverts.DeletedDate == null && cities.DeletedDate == null

                             select new CompanyUserAdvertCityDTO
                             {
                                 Id = companyUserAdvertCities.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUserAdvertCities.CompanyUserId,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 AdvertId = companyUserAdvertCities.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 WorkCityId = companyUserAdvertCities.WorkCityId,
                                 WorkCityName = cities.CityName,
                                 CreatedDate = companyUserAdvertCities.CreatedDate,
                                 UpdatedDate = companyUserAdvertCities.UpdatedDate,
                                 DeletedDate = companyUserAdvertCities.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<CompanyUserAdvertCityDTO>> GetAllByIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserAdvertCities in context.CompanyUserAdvertCities
                             join companyUserAdverts in context.CompanyUserAdverts on companyUserAdvertCities.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on companyUserAdvertCities.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUserAdvertCities.UserId equals users.Id
                             join cities in context.Cities on companyUserAdvertCities.WorkCityId equals cities.Id

                             where companyUserAdvertCities.AdvertId == id && companyUserAdvertCities.DeletedDate == null && users.DeletedDate == null && companyUserAdverts.DeletedDate == null && cities.DeletedDate == null

                             select new CompanyUserAdvertCityDTO
                             {
                                 Id = companyUserAdvertCities.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUserAdvertCities.CompanyUserId,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 AdvertId = companyUserAdvertCities.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 WorkCityId = companyUserAdvertCities.WorkCityId,
                                 WorkCityName = cities.CityName,
                                 CreatedDate = companyUserAdvertCities.CreatedDate,
                                 UpdatedDate = companyUserAdvertCities.UpdatedDate,
                                 DeletedDate = companyUserAdvertCities.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
    }


}
