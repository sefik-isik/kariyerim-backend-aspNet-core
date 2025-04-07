using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TaxOffice : Entity, IEntity
    {
        public int CityId { get; set; }
        public string RegionName { get; set; }
        public int TaxOfficeCode { get; set; }
        public string TaxOfficeName { get; set; }
    }
}
