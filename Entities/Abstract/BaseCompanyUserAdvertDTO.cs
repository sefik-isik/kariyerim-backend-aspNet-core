using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public class BaseCompanyUserAdvertDTO : BaseAdvertDTO, IDto
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public string CompanyUserId { get; set; }
        public string CompanyUserName { get; set; }
        public string AdvertId { get; set; }
        public string AdvertName { get; set; }
    }
}
