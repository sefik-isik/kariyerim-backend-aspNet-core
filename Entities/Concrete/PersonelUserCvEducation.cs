using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PersonelUserCvEducation : BaseCv, IEntity
    {
        public string EducationInfo { get; set; }
        public int UniversityId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Abandonment { get; set; }
        public int FacultyId { get; set; }
        public string Detail { get; set; }

    }
}
