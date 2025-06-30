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
        IResult Add(Region region);
        IResult Update(Region region);
        IResult Delete(Region region);
        IResult Terminate(Region region);
        IDataResult<List<Region>> GetAll();
        IDataResult<List<Region>> GetDeletedAll();
        IDataResult<Region> GetById(string id);

        //DTO
        IDataResult<List<RegionDTO>> GetAllDTO();
        IDataResult<List<RegionDTO>> GetDeletedAllDTO();
    }
}
