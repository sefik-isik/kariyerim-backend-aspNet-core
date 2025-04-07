using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectorService
    {
        IResult Add(Sector companyUserSector);
        IResult Update(Sector companyUserSector);
        IResult Delete(Sector companyUserSector);
        IDataResult<List<Sector>> GetAll();
        IDataResult<Sector> GetById(int companyUserSectorId);
        
    }
}
