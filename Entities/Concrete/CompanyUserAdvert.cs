using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyUserAdvert : BaseCompanyUser, IEntity
    {
        public string AdvertName { get; set; }
        public string AdvertImageName { get; set; }
        public string AdvertImagePath { get; set; }
        public string AdvertImageOwnName { get; set; }
        public string WorkAreaId { get; set; }
        public string WorkingMethodId { get; set; }
        public string ExperienceId { get; set; }
        public string DepartmentId { get; set; }
        public string LicenseDegreeId { get; set; }
        public string PositionId { get; set; }
        public string PositionLevelId { get; set; }
        public bool MilitaryStatus { get; set; }
        public string LanguageId { get; set; }
        public string LanguageLevelId { get; set; }
        public string DriverLicenceId { get; set; }
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public string RegionId { get; set; }
        public string SectorId { get; set; }
    }
}
