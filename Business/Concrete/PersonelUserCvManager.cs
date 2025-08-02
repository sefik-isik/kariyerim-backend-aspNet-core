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
    public class PersonelUserCvManager : IPersonelUserCvService
    {
        IPersonelUserCvDal _personelUserCvDal;
        IUserService _userService;

        public PersonelUserCvManager(IPersonelUserCvDal cvDal, IUserService userService)
        {
            _personelUserCvDal = cvDal;
            _userService = userService;
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(PersonelUserCv personelUserCv)
        {
            if (_userService.GetById(personelUserCv.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            IResult result = await BusinessRules.Run(IsNameExist(personelUserCv.CvName));

            if (result != null)
            {
                return result;
            }
            await _personelUserCvDal.AddAsync(personelUserCv);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(PersonelUserCv personelUserCv)
        {
            if (_userService.GetById(personelUserCv.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCvDal.UpdateAsync(personelUserCv);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(PersonelUserCv personelUserCv)
        {
            if (_userService.GetById(personelUserCv.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCvDal.Delete(personelUserCv);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(PersonelUserCv personelUserCv)
        {
            await _personelUserCvDal.Terminate(personelUserCv);
            await _personelUserCvDal.TerminateSubDatas(personelUserCv.Id);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCv>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCv>>(await _personelUserCvDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCv>>(await _personelUserCvDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCv>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCv>>(await _personelUserCvDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCv>>(await _personelUserCvDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserCv?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCv?>(await _personelUserCvDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCv?>(await _personelUserCvDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        [SecuredOperation("admin")]
        public async Task<PersonelUserCv?> GetPersonelUserCv(string cvId)
        {
            return await _personelUserCvDal.Get(c => c.Id == cvId);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserCvDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCvDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserCvDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _personelUserCvDal.GetAll(c => c.CvName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
