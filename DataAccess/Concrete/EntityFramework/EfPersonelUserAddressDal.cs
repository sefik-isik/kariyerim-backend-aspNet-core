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
        public List<PersonelUserAddressDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAddresses in context.PersonelUserAddresses
                             join personelUsers in context.PersonelUsers on personelUserAddresses.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join counties in context.Countries on personelUserAddresses.CountryId equals counties.Id
                             join cities in context.Cities on personelUserAddresses.CityId equals cities.Id
                             join regions in context.Regions on personelUserAddresses.RegionId equals regions.Id

                             select new PersonelUserAddressDTO
                             {
                                 Id = personelUserAddresses.Id,
                                 PersonelUserId = personelUsers.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
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


        
    }
}
