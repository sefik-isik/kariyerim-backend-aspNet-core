using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Country : Entity, IEntity
    {
        public string CountryName { get; set; }
        public string CountryIso { get; set; }
    }
}
