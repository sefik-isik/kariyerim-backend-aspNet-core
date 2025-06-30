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
        IResult Add(UniversityImage universityImage);
        IResult Update(UniversityImage universityImage);
        IResult Delete(UniversityImage universityImage);
        IResult Terminate(UniversityImage universityImage);
        IDataResult<List<UniversityImage>> GetAll();
        IDataResult<List<UniversityImage>> GetDeletedAll();
        IDataResult<List<UniversityImage>> GetAllById(string id);
        IDataResult<UniversityImage> GetById(string id);
        IResult DeleteImage(UniversityImage universityImage);
    }
}
