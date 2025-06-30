using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public abstract class BaseAdvertDTO : Dto, IDto
    {
        public string AdvertId { get; set; }
        public string AdvertName { get; set; }
    }
}
