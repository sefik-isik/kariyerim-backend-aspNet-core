using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public abstract class BaseUniversityDTO : Dto, IDto
    {
        public string UniversityId { get; set; }
        public string UniversityName { get; set; }
    }
}
