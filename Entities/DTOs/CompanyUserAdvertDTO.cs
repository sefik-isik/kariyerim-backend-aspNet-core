using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyUserAdvertDTO : BaseCompanyUserDTO, IDto
    {
        public string AdvertName { get; set; }
        public string AdvertImageName { get; set; }
        public string AdvertImagePath { get; set; }
        public string AdvertImageOwnName { get; set; }
        public string WorkAreaId { get; set; }
        public string WorkAreaName { get; set; }
        public string WorkingMethodId { get; set; }
        public string WorkingMethodName { get; set; }
        public string ExperienceId { get; set; }
        public string ExperienceName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string LicenseDegreeId { get; set; }
        public string LicenseDegreeName { get; set; }
    }
}
