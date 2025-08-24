using Business.Abstract;
using Core.Entities.Abstract;
using Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaginationUriManager : IPaginationUriService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaginationUriManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Uri GetPageUri(PageModel pageModel)
        {
            var baseUri = _httpContextAccessor.GetRequestUri();
            var route = _httpContextAccessor.GetRoute();
            var endpoint = new Uri(string.Concat(baseUri, route));
            var queryUri = QueryHelpers.AddQueryString($"{endpoint}", "pageNumber", $"{pageModel.PageIndex}");
            queryUri = QueryHelpers.AddQueryString(queryUri, "pageSize", $"{pageModel.PageSize}");
            return new Uri(queryUri);
        }

        public Uri GetPageListUri(PageListModel pageListModel)
        {
            var baseUri = _httpContextAccessor.GetRequestUri();
            var route = _httpContextAccessor.GetRoute();
            var endpoint = new Uri(string.Concat(baseUri, route));
            var queryUri = QueryHelpers.AddQueryString($"{endpoint}", "pageNumber", $"{pageListModel.PageIndex}");
            queryUri = QueryHelpers.AddQueryString(queryUri, "pageSize", $"{pageListModel.PageSize}");
            return new Uri(queryUri);
        }
    }
}
