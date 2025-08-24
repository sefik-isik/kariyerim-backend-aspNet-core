using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdvertFilterManager : IAdvertFilterService
    {
        IAdvertFilterDal _advertFilterDal;

        public AdvertFilterManager(IAdvertFilterDal advertFilterDal)
        {
            _advertFilterDal = advertFilterDal;
        }

        public async Task<IResult> Add(AdvertFilter advertFilter)
        {
            if (!string.IsNullOrEmpty(advertFilter.FilterId) && !string.IsNullOrEmpty(advertFilter.FilterName) && !string.IsNullOrEmpty(advertFilter.FilterValue))
            {
                var datas = await _advertFilterDal.GetAll();
                var query = datas.AsQueryable();

                query = query.Where(c => c.FilterId == advertFilter.FilterId && c.FilterName == advertFilter.FilterName && c.FilterValue == advertFilter.FilterValue);

                if (query.Count() > 0)
                {
                    return new ErrorResult(advertFilter.FilterName + " daha önce filtrelenmiş");
                }

                await _advertFilterDal.AddAsync(advertFilter);
            }

            return new SuccessResult(Messages.SuccessAdded);
        }

        public async Task<IResult> Terminate(AdvertFilter advertFilter)
        {
            await _advertFilterDal.Terminate(advertFilter);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        public async Task<IDataResult<List<AdvertFilter>>> GetFiltersBySearchId(string filterid)
        {
            var result = await _advertFilterDal.GetAll(f => f.FilterId == filterid);
            result = result.OrderBy(x => x.FilterName).ToList();
            return new SuccessDataResult<List<AdvertFilter>>(result, Messages.SuccessListed);
        }
    }
}
