using Entities.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel

{
    public class PageModel : IPageModel
    {
        public int ContactTotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int TotalPages { get; set; }
        public Uri? NextPage { get; set; }
        public Uri? PreviousPage { get; set; }
        public Uri? FirstPage { get; set; }
        public Uri? LastPage { get; set; }
        public Uri? CurrentPage { get; set; }
    }
}
