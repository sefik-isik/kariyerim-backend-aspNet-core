using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public interface IPageModel
    {
        int ContactTotalCount { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        string? SortColumn { get; set; }
        string? SortOrder { get; set; }
        int TotalPages { get; set; }
        Uri? NextPage { get; set; }
        Uri? PreviousPage { get; set; }
        Uri? FirstPage { get; set; }
        Uri? LastPage { get; set; }
        Uri? CurrentPage { get; set; }
    }
}
