using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public class BaseCompanyUserAdvert : BaseAdvert, IEntity
    {
        public string UserId { get; set; }
        public string CompanyUserId { get; set; }
    }
}
