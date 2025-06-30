using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UniversityDepartment : BaseUniversity, IEntity
    {
        public string FacultyId { get; set; }
        public string DepartmentId { get; set; }
    }
}
