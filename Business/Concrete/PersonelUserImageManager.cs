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
    public class PersonelUserImageManager : IPersonelUserImageService
    {
        IPersonelUserImageDal _personelUserImageDal;
        IUserService _userService;

        public PersonelUserImageManager(IPersonelUserImageDal personelUserImageDal, IUserService userService)
        {
            _personelUserImageDal = personelUserImageDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserImage personelUserImage)
        {
            _personelUserImageDal.Add(personelUserImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserImage personelUserImage)
        {
            _personelUserImageDal.Update(personelUserImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserImage personelUserImage)
        {
            _personelUserImageDal.Delete(personelUserImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserImage>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserImage>>(_personelUserImageDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserImage>>(_personelUserImageDal.GetAll());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserImage> GetById(int personelUserImageId)
        {
            return new SuccessDataResult<PersonelUserImage>(_personelUserImageDal.Get(c=>c.Id==personelUserImageId));
        }

        
    }
}
