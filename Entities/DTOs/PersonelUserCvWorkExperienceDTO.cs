using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserCvWorkExperienceDTO : BasePersonelDTOUser, IDto
    {
        public int CvId { get; set; }
        public string CvName { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public bool Working { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CompanySectorId { get; set; }
        public string CompanySectorName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int WorkingMethodId { get; set; }
        public string WorkingMethodName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public bool FoundJobInHere { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public string Detail { get; set; }
    }
}
