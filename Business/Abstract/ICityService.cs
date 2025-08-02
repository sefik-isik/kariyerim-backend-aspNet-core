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
    public interface ICityService
    {
        Task<IResult> Add(City city);
        Task<IResult> Update(City city);
        Task<IResult> Delete(City city);
        Task<IResult> Terminate(City city);
        Task<IDataResult<List<City>>> GetAll();
        Task<IDataResult<List<City>>> GetDeletedAll();
        Task<IDataResult<City?>> GetById(string id);

        //DTO
        Task<IDataResult<List<CityDTO>>> GetAllDTO();
        Task<IDataResult<List<CityDTO>>> GetDeletedAllDTO();
    }
}
