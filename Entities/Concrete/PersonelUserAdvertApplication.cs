using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PersonelUserAdvertApplication : BaseAdvert, IEntity
    {
        public string CompanyUserId { get; set; }
        public string PersonelUserId { get; set; }
        public string? PersonelUserCvId { get; set; }
    }
}
