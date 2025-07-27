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
        public IResult Add(PersonelUserCv personelUserCv)
        {
            if (_userService.GetById(personelUserCv.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            IResult result = BusinessRules.Run(IsNameExist(personelUserCv.CvName));

            if (result != null)
            {
                return result;
            }
            _personelUserCvDal.AddAsync(personelUserCv);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCv personelUserCv)
        {
            if (_userService.GetById(personelUserCv.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCvDal.UpdateAsync(personelUserCv);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCv personelUserCv)
        {
            if (_userService.GetById(personelUserCv.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCvDal.Delete(personelUserCv);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public IResult Terminate(PersonelUserCv personelUserCv)
        {
            _personelUserCvDal.Terminate(personelUserCv);
            _personelUserCvDal.TerminateSubDatas(personelUserCv.Id);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCv>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_personelUserCvDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_personelUserCvDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCv>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_personelUserCvDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_personelUserCvDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCv> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCv>(_personelUserCvDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCv>(_personelUserCvDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        [SecuredOperation("admin")]
        public PersonelUserCv GetPersonelUserCv(string cvId)
        {
            return _personelUserCvDal.Get(c => c.Id == cvId);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_personelUserCvDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_personelUserCvDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_personelUserCvDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_personelUserCvDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _personelUserCvDal.GetAll(c => c.CvName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
