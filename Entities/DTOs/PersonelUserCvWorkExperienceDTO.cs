using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserCvWorkExperienceDTO : BasePersonelUserCvDTO, IDto
    {
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public bool Working { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CompanySectorId { get; set; }
        public string CompanySectorName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string WorkingMethodId { get; set; }
        public string WorkingMethodName { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string RegionId { get; set; }
        public string RegionName { get; set; }
        public bool FoundJobInHere { get; set; }
        public string Detail { get; set; }
    }
}
