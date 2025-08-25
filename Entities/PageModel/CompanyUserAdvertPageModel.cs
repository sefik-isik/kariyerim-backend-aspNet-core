using Core.Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel
{
    public class CompanyUserAdvertPageModel : PageModel
    {
        public List<FilterDTO>? Filters { get; set; }
        public List<CompanyUserAdvertDTO>? PageContacts { get; set; }
    }
}
