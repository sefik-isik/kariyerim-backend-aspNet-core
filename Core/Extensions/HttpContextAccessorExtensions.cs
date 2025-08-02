using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class HttpContextAccessorExtensions
    {
        public static string GetRequestUri(this IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor));
            }

            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));
            }

            var request = httpContext.Request;
            return string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
        }

        public static string GetRoute(this IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor));
            }

            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));
            }

            return httpContext.Request.Path.Value;
        }
    }
}
