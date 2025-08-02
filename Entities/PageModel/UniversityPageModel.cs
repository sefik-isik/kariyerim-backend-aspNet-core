using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel
{
    public class UniversityPageModel : Core.Entities.Abstract.PageModel, Core.Entities.Abstract.IPageModel
    {
        public List<UniversityDTO>? PageContacts { get; set; }
    }
}
