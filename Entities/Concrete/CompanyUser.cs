using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyUser : BaseUser, IEntity
    {
        public string CompanyName { get; set; }
        public int SectorId { get; set; }
        public int TaxCityId { get; set; }
        public int TaxOfficeId { get; set; }
        public string TaxNumber { get; set; }
    }
}
