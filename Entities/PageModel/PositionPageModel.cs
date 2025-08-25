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
    public class PositionPageModel : PageModel
    {
        public List<Position>? PageContacts { get; set; }
        public string? Filter { get; set; }
    }
}
