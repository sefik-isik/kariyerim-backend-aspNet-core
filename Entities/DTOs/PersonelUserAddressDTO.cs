using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserAddressDTO : BasePersonelUserDTO, IDto
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string RegionId { get; set; }
        public string RegionName { get; set; }
        public string AddressDetail { get; set; }

    }
}
