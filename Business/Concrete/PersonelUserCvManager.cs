using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelUserCvManager : IPersonelUserCvService
    {
        IPersonelUserCvDal _cvDal;
        IUserService _userService;

        public PersonelUserCvManager(IPersonelUserCvDal cvDal, IUserService userService)
        {
            _cvDal = cvDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCv cv)
        {
            _cvDal.Add(cv);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCv cv)
        {
            _cvDal.Update(cv);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCv cv)
        {
            _cvDal.Delete(cv);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCv>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_cvDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_cvDal.GetAll());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCv> GetById(int userCvId)
        {
            return new SuccessDataResult<PersonelUserCv>(_cvDal.Get(u=>u.Id==userCvId));
        }

        
    }
}
