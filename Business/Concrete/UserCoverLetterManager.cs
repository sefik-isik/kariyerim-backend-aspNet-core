using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelUserCoverLetterManager : IPersonelUserCoverLetterService
    {
        IPersonelUserCoverLetterDal _personelUserCoverLetterDal;
        IUserService _userService;

        public PersonelUserCoverLetterManager(IPersonelUserCoverLetterDal personelUserCoverLetterDal, IUserService userService)
        {
            _personelUserCoverLetterDal = personelUserCoverLetterDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCoverLetter personelUserCoverLetter)
        {
            _personelUserCoverLetterDal.Add(personelUserCoverLetter);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCoverLetter personelUserCoverLetter)
        {
            _personelUserCoverLetterDal.Update(personelUserCoverLetter);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCoverLetter personelUserCoverLetter)
        {
            _personelUserCoverLetterDal.Delete(personelUserCoverLetter);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCoverLetter>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(_personelUserCoverLetterDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(_personelUserCoverLetterDal.GetAll());
            }

            
        }

        [SecuredOperation("admin")]
        public IDataResult<List<PersonelUserCoverLetter>> GetDeletedAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(_personelUserCoverLetterDal.GetDeletedAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(_personelUserCoverLetterDal.GetDeletedAll());
            }


        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCoverLetter> GetById(int personelUserCoverLetterId)
        {
            return new SuccessDataResult<PersonelUserCoverLetter>(_personelUserCoverLetterDal.Get(u=>u.Id== personelUserCoverLetterId));
        }

        
    }
}
