using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel
{
    public class SectorPageModel : Core.Entities.Abstract.PageModel, Core.Entities.Abstract.IPageModel
    {
        public List<Sector>? PageContacts { get; set; }
    }
}
