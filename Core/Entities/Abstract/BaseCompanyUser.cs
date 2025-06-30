using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public abstract class BaseCompanyUser: BaseUser, IEntity
    {
        public string CompanyUserId { get; set; }
    }
}
