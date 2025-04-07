using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class LicenseDegree : Entity, IEntity
    {
        public string LicenceName { get; set; }
    }
}
