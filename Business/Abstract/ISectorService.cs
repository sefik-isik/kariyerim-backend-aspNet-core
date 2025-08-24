using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectorService
    {
        Task<IResult> Add(Sector sector);
        Task<IResult> Update(Sector sector);
        Task<IResult> Delete(Sector sector);
        Task<IResult> Terminate(Sector sector);
        Task<IDataResult<List<Sector>>> GetAll();
        Task<IDataResult<List<Sector>>> GetDeletedAll();
        Task<IDataResult<Sector>> GetById(string id);
        Task<IDataResult<SectorPageModel>> GetAllByPage(SectorPageModel pageModel);

    }
}
