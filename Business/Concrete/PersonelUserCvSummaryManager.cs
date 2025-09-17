using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
        public async Task<IResult> Add(PersonelUserCvSummary personelUserCvSummary)
        {
            if (_userService.GetById(personelUserCvSummary.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }

            var result = await _personelUserCvSummaryDal.GetAll(c => c.CvId == personelUserCvSummary.CvId);

            if (result != null)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            await _personelUserCvSummaryDal.AddAsync(personelUserCvSummary);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(PersonelUserCvSummary personelUserCvSummary)
        {
            if (_userService.GetById(personelUserCvSummary.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCvSummaryDal.UpdateAsync(personelUserCvSummary);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(PersonelUserCvSummary personelUserCvSummary)
        {
            if (_userService.GetById(personelUserCvSummary.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCvSummaryDal.Delete(personelUserCvSummary);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(PersonelUserCvSummary personelUserCvSummary)
        {
            await _personelUserCvSummaryDal.Terminate(personelUserCvSummary);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvSummary>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(await _personelUserCvSummaryDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(await _personelUserCvSummaryDal.GetAll());
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvSummary>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(await _personelUserCvSummaryDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummary>>(await _personelUserCvSummaryDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserCvSummary?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCvSummary?>(await _personelUserCvSummaryDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCvSummary?>(await _personelUserCvSummaryDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvSummaryDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserCvSummaryDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummaryDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.CvId == userAdminDTO.Id), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummaryDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvSummaryDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserCvSummaryDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvSummaryDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvSummaryDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        
    }
}
