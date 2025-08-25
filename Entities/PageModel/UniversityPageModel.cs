using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel
{
    public class UniversityPageModel : PageModel
    {
        public List<UniversityDTO>? PageContacts { get; set; }
        public string? Filter { get; set; }
    }
}
