using Core.Entities.Concrete;
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
        IResult Add(Sector sector);
        IResult Update(Sector sector);
        IResult Delete(Sector sector);
        IResult Terminate(Sector sector);
        IDataResult<List<Sector>> GetAll();
        IDataResult<List<Sector>> GetDeletedAll();
        IDataResult<Sector> GetById(string id);
        
    }
}
