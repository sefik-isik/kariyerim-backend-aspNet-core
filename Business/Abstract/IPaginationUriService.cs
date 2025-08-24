using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaginationUriService
    {
        Uri GetPageUri(PageModel pageModel);
        Uri GetPageListUri(PageListModel pageListModel);
    }
}
