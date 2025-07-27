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
        IResult Add(SectorDescription sectorDescription);
        IResult Update(SectorDescription sectorDescription);
        IResult Delete(SectorDescription sectorDescription);
        IResult Terminate(SectorDescription sectorDescription);
        IDataResult<List<SectorDescription>> GetAll();
        IDataResult<List<SectorDescription>> GetDeletedAll();
        IDataResult<SectorDescription> GetById(string id);

        //DTO
        IDataResult<List<SectorDescriptionDTO>> GetAllDTO();
        IDataResult<List<SectorDescriptionDTO>> GetDeletedAllDTO();
        IDataResult<List<SectorDescriptionDTO>> GetAllBySectorIdDTO(string id);
    }
}
