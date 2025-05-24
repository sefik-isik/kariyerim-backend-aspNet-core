using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UniversityDepartment : Entity, IEntity
    {
        public int UniversityId { get; set; }
        public int FacultyId { get; set; }
        public int DepartmentId { get; set; }
    }
}
