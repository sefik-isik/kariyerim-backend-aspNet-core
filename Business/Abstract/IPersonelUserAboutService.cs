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
    public interface IPersonelUserAboutService
    {
        IResult Add(PersonelUserAbout cvAbout);
        IResult Update(PersonelUserAbout cvAbout);
        IResult Delete(PersonelUserAbout cvAbout);
        IDataResult<List<PersonelUserAbout>> GetAll(int UserId);
        IDataResult<PersonelUserAbout> GetById(int cvAboutId);
        
        //DTO
        IDataResult<List<PersonelUserAboutDTO>> GetAllDTO(int userId);
    }
}
