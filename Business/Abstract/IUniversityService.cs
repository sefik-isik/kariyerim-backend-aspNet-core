using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUniversityService
    {
        Task<IResult> Add(University university);
        Task<IResult> Update(University university);
        Task<IResult> Delete(University university);
        Task<IResult> Terminate(University university);
        Task<IDataResult<List<University>>> GetAll();
        Task<IDataResult<List<University>>> GetDeletedAll();
        Task<IDataResult<University>> GetById(string id);
        Task<IDataResult<UniversityPageModel>> GetAllByPage(UniversityPageModel pageModel);

        //DTO
        Task<IDataResult<List<UniversityDTO>>> GetAllDTO();
        Task<IDataResult<List<UniversityDTO>>> GetDeletedAllDTO();
        

    }
}
