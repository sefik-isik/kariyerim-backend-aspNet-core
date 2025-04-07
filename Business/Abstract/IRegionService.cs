using Core.Utilities.Results;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRegionService
    {
        IResult Add(Region region);
        IResult Update(Region region);
        IResult Delete(Region region);
        IDataResult<List<Region>> GetAll();
        IDataResult<Region> GetById(int regionId);
        

        //DTO
        IDataResult<List<RegionDTO>> GetRegionDTO();
        IDataResult<List<RegionDTO>> GetRegionDeletedDTO();
    }
}
