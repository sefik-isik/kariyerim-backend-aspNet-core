using Core.Entities.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel
{
    public class UniversityDepartmentPageModel : PageModel
    {
        public List<UniversityDepartment>? PageContacts { get; set; }
        public string? Filter { get; set; }
    }
}
