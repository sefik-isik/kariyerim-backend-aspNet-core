using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserAdminDTO : Dto
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
