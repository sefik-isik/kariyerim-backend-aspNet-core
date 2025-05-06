using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCityDal : EfEntityRepositoryBase<City, KariyerimContext>, ICityDal
    {
        public List<CityDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from countries in context.Countries
                             join city in context.Cities on countries.Id equals city.CountryId
                             where countries.DeletedDate == null 

                             select new CityDTO
                             {
                                 Id = city.Id,
                                 CityName = city.CityName,
                                 CountryIso = countries.CountryIso,
                                 CountryName = countries.CountryName,
                                 CountryId = city.CountryId,
                                 CreatedDate = city.CreatedDate,
                                 UpdatedDate = city.UpdatedDate,
                                 DeletedDate = city.DeletedDate,
                             };
                return result.ToList();
            }
        }
        public List<CityDTO> GetAllDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from countries in context.Countries
                             join city in context.Cities on countries.Id equals city.CountryId
                             where countries.DeletedDate != null

                             select new CityDTO
                             {
                                 Id = city.Id,
                                 CityName = city.CityName,
                                 CountryIso = countries.CountryIso,
                                 CountryName = countries.CountryName,
                                 CountryId = city.CountryId,
                                 CreatedDate = city.CreatedDate,
                                 UpdatedDate = city.UpdatedDate,
                                 DeletedDate = city.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}




