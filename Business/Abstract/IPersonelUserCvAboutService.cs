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
    public interface IPersonelUserCvAboutService
    {
        IResult Add(PersonelUserCvAbout cvAbout);
        IResult Update(PersonelUserCvAbout cvAbout);
        IResult Delete(PersonelUserCvAbout cvAbout);
        IDataResult<List<PersonelUserCvAbout>> GetAll(int UserId);
        IDataResult<PersonelUserCvAbout> GetById(int cvAboutId);
        
        //DTO
        IDataResult<List<PersonelUserCvAboutDTO>> GetPersonelUserCvAboutDTO(int userId);
        IDataResult<List<PersonelUserCvAboutDTO>> GetPersonelUserCvAboutDeletedDTO(int userId);
    }
}
