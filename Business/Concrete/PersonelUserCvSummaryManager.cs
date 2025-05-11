using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
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
        IPersonelUserService _personelUserService;
        IPersonelUserCvService _personelUserCvService;

        public PersonelUserCvSummaryManager(IPersonelUserCvSummaryDal cvSummaryDal, IUserService userService, IPersonelUserService personelUserService ,IPersonelUserCvService personelUserCvService)
        {
            _cvSummaryDal = cvSummaryDal;
            _userService = userService;
            _personelUserService = personelUserService;
            _personelUserCvService = personelUserCvService;


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
        public IDataResult<List<PersonelUserCvSummary>> GetAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_cvSummaryDal.GetAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_cvSummaryDal.GetAll());
            }
            
        }
        [SecuredOperation("admin")]
        public IDataResult<List<PersonelUserCvSummary>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_cvSummaryDal.GetDeletedAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_cvSummaryDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvSummary> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCvSummary>(_cvSummaryDal.Get(c => c.Id == userAdminDTO.Id && c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCvSummary>(_cvSummaryDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        
    }
}
