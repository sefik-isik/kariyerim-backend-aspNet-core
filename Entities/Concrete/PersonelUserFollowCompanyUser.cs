using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PersonelUserFollowCompanyUser : Entity, IEntity
    {
        public string CompanyUserId { get; set; }
        public string PersonelUserId { get; set; }
        
    }
}
