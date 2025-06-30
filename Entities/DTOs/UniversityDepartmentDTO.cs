using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UniversityDepartmentDTO : BaseUniversityDTO, IDto
    {
        public string FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
