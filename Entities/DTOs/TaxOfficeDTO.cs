using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TaxOfficeDTO : Dto, IDto
    {
        public string CityId { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string TaxOfficeCode { get; set; }
        public string TaxOfficeName { get; set; }
    }
}
