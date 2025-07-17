using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Department : Entity, IEntity
    {
        public string DepartmentName { get; set; }
        public bool IsCompany { get; set; }
    }
}
