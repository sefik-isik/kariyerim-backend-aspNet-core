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
                             join cities in context.Cities on countries.Id equals cities.CountryId
                             where cities.DeletedDate == null && countries.DeletedDate == null

                             select new CityDTO
                             {
                                 Id = cities.Id,
                                 CityName = cities.CityName,
                                 CountryIso = countries.CountryIso,
                                 CountryName = countries.CountryName,
                                 CountryId = cities.CountryId,
                                 CreatedDate = cities.CreatedDate,
                                 UpdatedDate = cities.UpdatedDate,
                                 DeletedDate = cities.DeletedDate,
                             };
                return result.ToList();
            }
        }
        public List<CityDTO> GetAllDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from countries in context.Countries
                             join cities in context.Cities on countries.Id equals cities.CountryId
                             where cities.DeletedDate != null && countries.DeletedDate == null

                             select new CityDTO
                             {
                                 Id = cities.Id,
                                 CityName = cities.CityName,
                                 CountryIso = countries.CountryIso,
                                 CountryName = countries.CountryName,
                                 CountryId = cities.CountryId,
                                 CreatedDate = cities.CreatedDate,
                                 UpdatedDate = cities.UpdatedDate,
                                 DeletedDate = cities.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}




