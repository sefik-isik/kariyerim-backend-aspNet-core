using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveByPatternAspect : MethodInterception
    {
        private string _pattern;
        private ICacheService _cacheService;

        public CacheRemoveByPatternAspect(string pattern)
        {
            _pattern = pattern;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheService.RemoveByPattern(_pattern);
        }
    }
}
