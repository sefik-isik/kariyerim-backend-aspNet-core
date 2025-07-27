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
    public interface IPositionDescriptionService
    {
        IResult Add(PositionDescription positionDescription);
        IResult Update(PositionDescription positionDescription);
        IResult Delete(PositionDescription positionDescription);
        IResult Terminate(PositionDescription positionDescription);
        IDataResult<List<PositionDescription>> GetAll();
        IDataResult<List<PositionDescription>> GetDeletedAll();
        IDataResult<PositionDescription> GetById(string id);

        //DTO
        IDataResult<List<PositionDescriptionDTO>> GetAllDTO();
        IDataResult<List<PositionDescriptionDTO>> GetDeletedAllDTO();
        IDataResult<List<PositionDescriptionDTO>> GetAllByPositionIdDTO(string id);
    }
}
