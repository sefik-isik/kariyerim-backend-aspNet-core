using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserAboutDTO : BasePersonelDTOUser, IDto
    {
        public string IdentityNumber { get; set; }
        public bool NationalStatus { get; set; }
        public int DriverLicenceId { get; set; }
        public string DriverLicenceName { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public bool MilitaryStatus { get; set; }
        public bool RetirementStatus { get; set; }
    }
}
