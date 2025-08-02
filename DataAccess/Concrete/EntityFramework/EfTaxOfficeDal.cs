using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfTaxOfficeDal : EfEntityRepositoryBase<TaxOffice, KariyerimContext>, ITaxOfficeDal
    {
        public async Task<List<TaxOfficeDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from taxOffices in context.TaxOffices
                             join cities in context.Cities on taxOffices.CityId equals cities.Id

                             where taxOffices.DeletedDate == null 

                             select new TaxOfficeDTO
                             {
                                 Id = taxOffices.Id,
                                 TaxOfficeName = taxOffices.TaxOfficeName,
                                 TaxOfficeCode=taxOffices.TaxOfficeCode,
                                 RegionName = taxOffices.RegionName,
                                 CityId = cities.Id,
                                 CityCode= cities.CityCode,
                                 CityName = cities.CityName,
                                 CreatedDate = taxOffices.CreatedDate,
                                 UpdatedDate = taxOffices.UpdatedDate,
                                 DeletedDate = taxOffices.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<TaxOfficeDTO>> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from taxOffices in context.TaxOffices
                             join cities in context.Cities on taxOffices.CityId equals cities.Id

                             where taxOffices.DeletedDate != null 

                             select new TaxOfficeDTO
                             {
                                 Id = taxOffices.Id,
                                 TaxOfficeName = taxOffices.TaxOfficeName,
                                 TaxOfficeCode = taxOffices.TaxOfficeCode,
                                 RegionName = taxOffices.RegionName,
                                 CityId = cities.Id,
                                 CityCode = cities.CityCode,
                                 CityName = cities.CityName,
                                 CreatedDate = taxOffices.CreatedDate,
                                 UpdatedDate = taxOffices.UpdatedDate,
                                 DeletedDate = taxOffices.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
