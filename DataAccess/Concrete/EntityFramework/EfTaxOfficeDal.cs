using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfTaxOfficeDal : EfEntityRepositoryBase<TaxOffice, KariyerimContext>, ITaxOfficeDal
    {
        public List<TaxOfficeDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from taxOffices in context.TaxOffices
                             join city in context.Cities on taxOffices.CityId equals city.Id

                             where taxOffices.DeletedDate == null 

                             select new TaxOfficeDTO
                             {
                                 Id = taxOffices.Id,
                                 TaxOfficeName = taxOffices.TaxOfficeName,
                                 TaxOfficeCode=taxOffices.TaxOfficeCode,
                                 RegionName = taxOffices.RegionName,
                                 CityId = taxOffices.CityId,
                                 CityName = city.CityName,
                                 CreatedDate = taxOffices.CreatedDate,
                                 UpdatedDate = taxOffices.UpdatedDate,
                                 DeletedDate = taxOffices.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<TaxOfficeDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from taxOffices in context.TaxOffices
                             join city in context.Cities on taxOffices.CityId equals city.Id

                             where taxOffices.DeletedDate != null 

                             select new TaxOfficeDTO
                             {
                                 Id = taxOffices.Id,
                                 TaxOfficeName = taxOffices.TaxOfficeName,
                                 TaxOfficeCode = taxOffices.TaxOfficeCode,
                                 RegionName = taxOffices.RegionName,
                                 CityId = taxOffices.CityId,
                                 CityName = city.CityName,
                                 CreatedDate = taxOffices.CreatedDate,
                                 UpdatedDate = taxOffices.UpdatedDate,
                                 DeletedDate = taxOffices.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
