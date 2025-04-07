using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserDTO : BasePersonelDTOUser, IDto
    {
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
