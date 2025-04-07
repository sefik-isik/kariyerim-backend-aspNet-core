using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PersonelUserCvWorkExperience : BaseCv, IEntity
    {
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public bool Working { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CompanySectorId { get; set; }
        public int DepartmentId { get; set; }
        public bool FoundJobInHere { get; set; }
        public int WorkingMethodId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public string Detail { get; set; } 


    }
}
