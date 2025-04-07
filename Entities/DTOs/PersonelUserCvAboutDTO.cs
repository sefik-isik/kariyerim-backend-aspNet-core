using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserCvAboutDTO : BasePersonelDTOUser, IDto
    {
        public int CvId { get ; set ; }
        public string CvName { get; set; }
        public bool NationalStatus { get; set; }
        public int DriverLicenseId { get; set; }
        public string DriverLicenseName { get; set; }
        public bool MilitaryStatus { get; set; }
        public bool RetirementStatus { get; set; }
    }
}
