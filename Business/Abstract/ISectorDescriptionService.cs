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
    public interface ISectorDescriptionService
    {
        Task<IResult> Add(SectorDescription sectorDescription);
        Task<IResult> Update(SectorDescription sectorDescription);
        Task<IResult> Delete(SectorDescription sectorDescription);
        Task<IResult> Terminate(SectorDescription sectorDescription);
        Task<IDataResult<List<SectorDescription>>> GetAll();
        Task<IDataResult<List<SectorDescription>>> GetDeletedAll();
        Task<IDataResult<SectorDescription>> GetById(string id);

        //DTO
        Task<IDataResult<List<SectorDescriptionDTO>>> GetAllDTO();
        Task<IDataResult<List<SectorDescriptionDTO>>> GetDeletedAllDTO();
        Task<IDataResult<List<SectorDescriptionDTO>>> GetAllBySectorIdDTO(string id);
    }
}
