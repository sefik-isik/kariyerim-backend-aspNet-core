using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserCvEducationDTO : BasePersonelUser, IDto
    {
        public int CvId { get ; set ; }
        public string CvName { get; set; }
        public string EducationInfo { get; set; }
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string Detail { get; set; }
    }
}
