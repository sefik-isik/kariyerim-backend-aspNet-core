using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public class BaseCompanyUserDTO:BaseUserDTO
    {
        public string CompanyUserId { get; set; }
        public string CompanyUserName { get; set; }
    }
}
