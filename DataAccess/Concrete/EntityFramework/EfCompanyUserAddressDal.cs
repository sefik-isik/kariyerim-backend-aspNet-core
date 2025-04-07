using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Security.Status;
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
    public class EfCompanyUserAddressDal : EfEntityRepositoryBase<CompanyUserAddress,KariyerimContext>, ICompanyUserAddressDal
    {
        public List<CompanyUserAddressDTO> GetCompanyUserAddressDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserAddresses in context.CompanyUserAddresses
                             join companyUsers in context.CompanyUsers on companyUserAddresses.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id
                             join countries in context.Countries on companyUserAddresses.CountryId equals countries.Id
                             join cities in context.Cities on companyUserAddresses.CityId equals cities.Id
                             join regions in context.Regions on companyUserAddresses.RegionId equals regions.Id
                             where companyUserAddresses.DeletedDate == null
                             select new CompanyUserAddressDTO
                             {
                                 Id = companyUserAddresses.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 CountryId=countries.Id,
                                 CountryName = countries.CountryName,
                                 CityId=cities.Id,
                                 CityName = cities.CityName,
                                 RegionId=regions.Id,
                                 RegionName = regions.RegionName,
                                 AddressDetail = companyUserAddresses.AddressDetail,
                                 CreatedDate = companyUserAddresses.CreatedDate,
                                 UpdatedDate = companyUserAddresses.UpdatedDate,
                                 DeletedDate = companyUserAddresses.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<CompanyUserAddressDTO> GetCompanyUserAddressDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserAddresses in context.CompanyUserAddresses
                             join companyUsers in context.CompanyUsers on companyUserAddresses.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id
                             join countries in context.Countries on companyUserAddresses.CountryId equals countries.Id
                             join cities in context.Cities on companyUserAddresses.CityId equals cities.Id
                             join regions in context.Regions on companyUserAddresses.RegionId equals regions.Id
                             where companyUserAddresses.DeletedDate != null
                             select new CompanyUserAddressDTO
                             {
                                 Id = companyUserAddresses.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 CountryId = countries.Id,
                                 CountryName = countries.CountryName,
                                 CityId = cities.Id,
                                 CityName = cities.CityName,
                                 RegionId = regions.Id,
                                 RegionName = regions.RegionName,
                                 AddressDetail = companyUserAddresses.AddressDetail,
                                 CreatedDate = companyUserAddresses.CreatedDate,
                                 UpdatedDate = companyUserAddresses.UpdatedDate,
                                 DeletedDate = companyUserAddresses.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
