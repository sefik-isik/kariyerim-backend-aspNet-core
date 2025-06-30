using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyUserAddress : BaseCompanyUser, IEntity
    {
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public string RegionId { get; set; }
        public string AddressDetail { get; set; }
    }
}
