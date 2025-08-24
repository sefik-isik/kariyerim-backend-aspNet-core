using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AdvertFilter : Entity, IEntity
    {
        public string? FilterId { get; set; }
        public string? FilterName { get; set; }
        public string? FilterValue { get; set; }
    }
}
