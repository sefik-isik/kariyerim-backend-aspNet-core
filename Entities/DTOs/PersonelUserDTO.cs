using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserDTO : BaseUserDTO, IDto
    {
        public string IdentityNumber { get; set; }
        public bool Gender { get; set; }
        public string? Title { get; set; }
        public string LicenseDegreeId { get; set; }
        public string LicenseDegreeName { get; set; }
        public string BirthPlaceId { get; set; }
        public string BirthPlaceName { get; set; }
        public string DriverLicenceId { get; set; }
        public string DriverLicenceName { get; set; }
        public bool NationalStatus { get; set; }
        public bool MilitaryStatus { get; set; }
        public bool RetirementStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ImageName { get; set; }
        public string? ImageOwnName { get; set; }
        public string? ImagePath { get; set; }
    }
}
