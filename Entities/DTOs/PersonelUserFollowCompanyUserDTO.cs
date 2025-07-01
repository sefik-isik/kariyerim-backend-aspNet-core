using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserFollowCompanyUserDTO : Dto, IDto
    {
        public string PersonelUserId { get; set; }
        public string CompanyUserId { get; set; }
    }
}
