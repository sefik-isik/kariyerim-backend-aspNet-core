using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel
{
    public class PositionPageModel : Core.Entities.Abstract.PageModel, Core.Entities.Abstract.IPageModel
    {

        public List<Position>? PageContacts { get; set; }
    }
}
