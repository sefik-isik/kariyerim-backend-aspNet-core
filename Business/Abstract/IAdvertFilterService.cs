using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdvertFilterService
    {
        Task<IResult> Add(AdvertFilter advertFilter);
        Task<IResult> Terminate(AdvertFilter advertFilter);
        Task<IDataResult<List<AdvertFilter>>> GetFiltersBySearchId(string filterid);
    }
}
