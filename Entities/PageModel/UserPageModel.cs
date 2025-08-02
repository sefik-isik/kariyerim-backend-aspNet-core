using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel
{
    public class UserPageModel : Core.Entities.Abstract.PageModel, Core.Entities.Abstract.IPageModel
    {

        public List<User>? PageContacts { get; set; }
    }
}
