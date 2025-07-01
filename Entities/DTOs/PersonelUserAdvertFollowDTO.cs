using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserAdvertFollowDTO : BaseAdvertDTO, IDto
    {
        public string CompanyUserId { get; set; }
        public string CompanyUserName { get; set; }
        public string PersonelUserId { get; set; }
        public string IdentityNumber { get; set; }
    }
}
