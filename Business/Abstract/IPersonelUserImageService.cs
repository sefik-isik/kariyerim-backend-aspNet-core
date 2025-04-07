using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonelUserImageService
    {
        IResult Add(PersonelUserImage personelUserImage);
        IResult Update(PersonelUserImage personelUserImage);
        IResult Delete(PersonelUserImage personelUserImage);
        IDataResult<List<PersonelUserImage>> GetAll(int UserId);
        IDataResult<PersonelUserImage> GetById(int personelUserImageId);
        
    }
}
