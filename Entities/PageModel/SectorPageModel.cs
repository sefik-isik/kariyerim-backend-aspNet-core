using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel
{
    public class SectorPageModel : PageModel
    {
        public List<Sector>? PageContacts { get; set; }
        public string? Filter { get; set; }
    }
}
