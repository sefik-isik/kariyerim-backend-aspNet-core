namespace Core.Entities.Abstract
{
    public class PageListModel : IPageModel
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
