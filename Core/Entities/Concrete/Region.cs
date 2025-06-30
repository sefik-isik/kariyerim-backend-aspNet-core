using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Region : Entity, IEntity
    {
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public string RegionName { get; set; }
    }
}
