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
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public string AddressDetail { get; set; }
    }
}
