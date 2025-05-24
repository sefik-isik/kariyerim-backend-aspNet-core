using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UniversityFacultyDTO : Dto, IDto
    {
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
    }
}
