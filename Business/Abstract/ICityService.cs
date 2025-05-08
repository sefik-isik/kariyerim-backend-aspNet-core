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
        IResult Add(City city);
        IResult Update(City city);
        IResult Delete(City city);
        IDataResult<List<City>> GetAll();

        IDataResult<List<City>> GetDeletedAll();
        IDataResult<City> GetById(int id);
        

        //DTO
        IDataResult<List<CityDTO>> GetAllDTO();
        IDataResult<List<CityDTO>> GetAllDeletedDTO();

    }
}
