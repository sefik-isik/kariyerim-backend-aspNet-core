using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
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
        IPersonelUserCvSummaryDal _personelUserCvSummaryDal;
        IUserService _userService;

        public PersonelUserCvSummaryManager(IPersonelUserCvSummaryDal cvSummaryDal, IUserService userService)
        {
            _personelUserCvSummaryDal = cvSummaryDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCvSummary personelUserCvSummary)
        {
            if (_userService.GetById(personelUserCvSummary.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCvSummaryDal.AddAsync(personelUserCvSummary);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCvSummary personelUserCvSummary)
        {
            if (_userService.GetById(personelUserCvSummary.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCvSummaryDal.UpdateAsync(personelUserCvSummary);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCvSummary personelUserCvSummary)
        {
            if (_userService.GetById(personelUserCvSummary.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCvSummaryDal.Delete(personelUserCvSummary);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public IResult Terminate(PersonelUserCvSummary personelUserCvSummary)
        {
            _personelUserCvSummaryDal.Terminate(personelUserCvSummary);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvSummary>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_personelUserCvSummaryDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_personelUserCvSummaryDal.GetAll());
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvSummary>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_personelUserCvSummaryDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(_personelUserCvSummaryDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvSummary> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCvSummary>(_personelUserCvSummaryDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCvSummary>(_personelUserCvSummaryDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvSummaryDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummaryDTO>>(_personelUserCvSummaryDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummaryDTO>>(_personelUserCvSummaryDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvSummaryDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummaryDTO>>(_personelUserCvSummaryDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummaryDTO>>(_personelUserCvSummaryDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }
    }
}
