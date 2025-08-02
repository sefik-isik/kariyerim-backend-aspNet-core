using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRegionDal : EfEntityRepositoryBase<Region, KariyerimContext>,IRegionDal
    {
        public async Task<List<RegionDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from regions in context.Regions
                             join cities in context.Cities on regions.CityId equals cities.Id
                             join countries in context.Countries on cities.CountryId equals countries.Id

                             where regions.DeletedDate == null && countries.DeletedDate == null && cities.DeletedDate == null

                             select new RegionDTO
                             {
                                 Id = regions.Id,
                                 RegionName = regions.RegionName,
                                 CityId = cities.Id,
                                 CityCode = cities.CityCode,
                                 CityName = cities.CityName,
                                 CountryId = cities.CountryId,
                                 CountryName=countries.CountryName,
                                 CreatedDate = regions.CreatedDate,
                                 UpdatedDate = regions.UpdatedDate,
                                 DeletedDate = regions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
       public async Task<List<RegionDTO>> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from regions in context.Regions
                             join cities in context.Cities on regions.CityId equals cities.Id
                             join countries in context.Countries on cities.CountryId equals countries.Id

                             where regions.DeletedDate != null && countries.DeletedDate == null && cities.DeletedDate == null

                             select new RegionDTO
                             {
                                 Id = regions.Id,
                                 RegionName = regions.RegionName,
                                 CityId = cities.Id,
                                 CityCode = cities.CityCode,
                                 CityName = cities.CityName,
                                 CountryId = cities.CountryId,
                                 CountryName = countries.CountryName,
                                 CreatedDate = regions.CreatedDate,
                                 UpdatedDate = regions.UpdatedDate,
                                 DeletedDate = regions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
