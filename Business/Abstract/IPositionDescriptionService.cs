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
        Task<IResult> Add(PositionDescription positionDescription);
        Task<IResult> Update(PositionDescription positionDescription);
        Task<IResult> Delete(PositionDescription positionDescription);
        Task<IResult> Terminate(PositionDescription positionDescription);
        Task<IDataResult<List<PositionDescription>>> GetAll();
        Task<IDataResult<List<PositionDescription>>> GetDeletedAll();
        Task<IDataResult<PositionDescription>> GetById(string id);

        //DTO
        Task<IDataResult<List<PositionDescriptionDTO>>> GetAllDTO();
        Task<IDataResult<List<PositionDescriptionDTO>>> GetDeletedAllDTO();
        Task<IDataResult<List<PositionDescriptionDTO>>> GetAllByPositionIdDTO(string id);
    }
}
