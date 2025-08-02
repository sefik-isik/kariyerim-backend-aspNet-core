using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Abstract
{
    public interface IUniversityImageService
    {
        Task<IResult> Add(UniversityImage universityImage);
        Task<IResult> Update(UniversityImage universityImage);
        Task<IResult> Delete(UniversityImage universityImage);
        Task<IResult> Terminate(UniversityImage universityImage);
        Task<IResult> DeleteImage(UniversityImage universityImage);
        Task<IDataResult<List<UniversityImage>>> GetAll();
        Task<IDataResult<List<UniversityImage>>> GetDeletedAll();
        Task<IDataResult<List<UniversityImage>>> GetAllById(string id);
        Task<IDataResult<UniversityImage>> GetById(string id);
        
    }
}
