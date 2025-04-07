using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class DriverLicense : Entity, IEntity
    {
        public string LicenseName { get; set; }
    }
}
