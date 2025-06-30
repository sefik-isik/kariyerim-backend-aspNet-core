using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CityDTO: Dto, IDto
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryIso { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
    }
}
