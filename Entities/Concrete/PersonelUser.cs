using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PersonelUser : BaseUser, IEntity
    {
        public string IdentityNumber { get; set; }
        public bool Gender { get; set; }
        public int LicenceDegreeId { get; set; }
        public int BirthPlaceId { get; set; }
        public bool NationalStatus { get; set; }
        public bool MilitaryStatus { get; set; }
        public bool RetirementStatus { get; set; }
        public int DriverLicenceId { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
