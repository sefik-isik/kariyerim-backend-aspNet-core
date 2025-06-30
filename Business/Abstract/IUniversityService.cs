using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUniversityService
    {
        IResult Add(University university);
        IResult Update(University university);
        IResult Delete(University university);
        IResult Terminate(University university);
        IDataResult<List<University>> GetAll();
        IDataResult<List<University>> GetDeletedAll();
        IDataResult<University> GetById(string id);
        

        //DTO
        IDataResult<List<UniversityDTO>> GetAllDTO();
        IDataResult<List<UniversityDTO>> GetDeletedAllDTO();

    }
}
