using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyUserDepartmentDTO : BaseCompanyUser, IDto
    {
        public string CompanyUserName { get; set; }

        public string DepartmentName { get; set; }
    }
}
