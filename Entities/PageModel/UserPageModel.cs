using Core.Entities.Concrete;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel
{
    public class UserPageModel : PageModel
    {
        public List<User>? PageContacts { get; set; }
        public string? Filter { get; set; }
    }
}
