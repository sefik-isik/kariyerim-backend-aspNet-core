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
    public class EfPersonelUserAddressDal : EfEntityRepositoryBase<PersonelUserAddress, KariyerimContext>,IPersonelUserAddressDal
    {
        public List<PersonelUserAddressDTO> GetPersonelUserAddressDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAddresses in context.PersonelUserAddresses
                             join personelUsers in context.PersonelUsers on personelUserAddresses.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join counties in context.Countries on personelUserAddresses.CountryId equals counties.Id
                             join cities in context.Cities on personelUserAddresses.CityId equals cities.Id
                             join regions in context.Regions on personelUserAddresses.RegionId equals regions.Id
                             where personelUserAddresses.DeletedDate==null
                             select new PersonelUserAddressDTO
                             {
                                 Id = personelUserAddresses.Id,
                                 PersonelUserId = personelUsers.Id,
                                 UserId = users.Id,
                                 CountryId = counties.Id,
                                 CountryName = counties.CountryName,
                                 CityId = cities.Id,
                                 CityName = cities.CityName,
                                 RegionId = regions.Id,
                                 RegionName = regions.RegionName,
                                 AddressDetail = personelUserAddresses.AddressDetail,
                                 CreatedDate = personelUserAddresses.CreatedDate,
                                 UpdatedDate = personelUserAddresses.UpdatedDate,
                                 DeletedDate = personelUserAddresses.DeletedDate,
                             };
                return result.ToList();
            }
        }


        public List<PersonelUserAddressDTO> GetPersonelUserAddressDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from userAddress in context.PersonelUserAddresses
                             join userName in context.PersonelUsers on userAddress.Id equals userName.Id
                             join county in context.Countries on userAddress.CountryId equals county.Id
                             join city in context.Cities on userAddress.CityId equals city.Id
                             join region in context.Regions on userAddress.RegionId equals region.Id
                             where userAddress.DeletedDate != null
                             select new PersonelUserAddressDTO
                             {
                                 Id = userAddress.Id,
                                 CountryId = county.Id,
                                 CountryName = county.CountryName,
                                 CityId = city.Id,
                                 CityName = city.CityName,
                                 RegionId = region.Id,
                                 RegionName = region.RegionName,
                                 AddressDetail = userAddress.AddressDetail,
                                 CreatedDate = userAddress.CreatedDate,
                                 UpdatedDate = userAddress.UpdatedDate,
                                 DeletedDate = userAddress.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
