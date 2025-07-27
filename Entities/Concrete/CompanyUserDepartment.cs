using Core.Entities.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyUserDepartment :Entity, IEntity
    {
        public string DepartmentName { get; set; }
    }
}
