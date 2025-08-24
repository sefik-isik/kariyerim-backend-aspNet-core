using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel
{
    public class CompanyUserAdvertPageModel : Core.Entities.Abstract.PageListModel, Core.Entities.Abstract.IPageModel
    {
        public List<CompanyUserAdvertDTO>? PageContacts { get; set; }
        public List<FilterDTO>? Filters { get; set; }
    }
}
