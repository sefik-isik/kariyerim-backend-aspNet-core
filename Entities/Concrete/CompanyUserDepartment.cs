using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyUserDepartment : BaseCompanyUser, IEntity
    {
        public string DepartmentName { get; set; }
    }
}
