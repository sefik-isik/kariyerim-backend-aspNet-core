using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelUserCvSummaryManager : IPersonelUserCvSummaryService
    {
        IPersonelUserCvSummaryDal _cvSummaryDal;
        IUserService _userService;

        public PersonelUserCvSummaryManager(IPersonelUserCvSummaryDal cvSummaryDal, IUserService userService)
        {
            _cvSummaryDal = cvSummaryDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCvSummary cvSummary)
        {
            _cvSummaryDal.Add(cvSummary);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCvSummary cvSummary)
        {
            _cvSummaryDal.Update(cvSummary);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCvSummary cvSummary)
        {
            _cvSummaryDal.Delete(cvSummary);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvSummary>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_cvSummaryDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_cvSummaryDal.GetAll());
            }
            
        }
        [SecuredOperation("admin")]
        public IDataResult<List<PersonelUserCvSummary>> GetDeletedAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_cvSummaryDal.GetDeletedAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_cvSummaryDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvSummary> GetById(int cvSummaryId)
        {
            return new SuccessDataResult<PersonelUserCvSummary>(_cvSummaryDal.Get(c=> c.Id == cvSummaryId));
        }

        
    }
}
