using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserDTO : BaseDTOUser, IDto
    {
        public required string IdentityNumber { get; set; }
        public bool Gender { get; set; }
        public int LicenceDegreeId { get; set; }
        public string LicenceDegreeName { get; set; }
        public int BirthPlaceId { get; set; }
        public required string BirthPlaceName { get; set; }
        public bool NationalStatus { get; set; }
        public bool MilitaryStatus { get; set; }
        public bool RetirementStatus { get; set; }
        public int DriverLicenceId { get; set; }
        public required string DriverLicenceName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
