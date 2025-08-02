using Core.Utilities.Results;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRegionService
    {
        Task<IResult> Add(Region region);
        Task<IResult> Update(Region region);
        Task<IResult> Delete(Region region);
        Task<IResult> Terminate(Region region);
        Task<IDataResult<List<Region>>> GetAll();
        Task<IDataResult<List<Region>>> GetDeletedAll();
        Task<IDataResult<Region>> GetById(string id);

        //DTO
        Task<IDataResult<List<RegionDTO>>> GetAllDTO();
        Task<IDataResult<List<RegionDTO>>> GetDeletedAllDTO();
    }
}
