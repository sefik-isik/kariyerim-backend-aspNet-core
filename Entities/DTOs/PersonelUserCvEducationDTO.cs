using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserCvEducationDTO : BasePersonelUserCvDTO, IDto
    {
        public string EducationInfo { get; set; }
        public string UniversityId { get; set; }
        public string UniversityName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string FacultyId { get; set; }
        public string FacultyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Abandonment { get; set; }
        public string Detail { get; set; }
    }
}
