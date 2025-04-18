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
        public int CvId { get; set; }
        public int LicenceId { get; set; }
        public int BirthPlaceId { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
