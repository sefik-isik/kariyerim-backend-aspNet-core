using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PersonelUserAbout : BasePersonelUser, IEntity
    {
        public int GenderId { get; set; }
        public bool NationalStatus { get; set; }
        public int DriverLicenceId { get; set; }
        public bool MilitaryStatus { get; set; }
        public bool RetirementStatus { get; set; }

    }
}
