using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRegionDal : EfEntityRepositoryBase<Region, KariyerimContext>,IRegionDal
    {
        public List<RegionDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from region in context.Regions
                             join city in context.Cities on region.CityId equals city.Id

                             where region.DeletedDate == null 

                             select new RegionDTO
                             {
                                 Id = region.Id,
                                 RegionName = region.RegionName,
                                 CityId = city.Id,
                                 CityName = city.CityName,
                                 CreatedDate = region.CreatedDate,
                                 UpdatedDate = region.UpdatedDate,
                                 DeletedDate = region.DeletedDate,
                             };
                return result.ToList();
            }
        }
       public List<RegionDTO> GetAllDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from region in context.Regions
                             join city in context.Cities on region.CityId equals city.Id

                             where region.DeletedDate != null 

                             select new RegionDTO
                             {
                                 Id = region.Id,
                                 RegionName = region.RegionName,
                                 CityId = city.Id,
                                 CityName = city.CityName,
                                 CreatedDate = region.CreatedDate,
                                 UpdatedDate = region.UpdatedDate,
                                 DeletedDate = region.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
