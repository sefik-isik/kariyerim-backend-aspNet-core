using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelUserAdvertFollowManager : IPersonelUserAdvertFollowService
    {
        IPersonelUserAdvertFollowDal _personelUserAdvertFollowDal;
        IUserService _userService;

        public PersonelUserAdvertFollowManager(IPersonelUserAdvertFollowDal personelUserAdvertFollowDal, IUserService userService)
        {
            _personelUserAdvertFollowDal = personelUserAdvertFollowDal;
            _userService = userService;

        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(PersonelUserAdvertFollow personelUserAdvertFollow)
        {
            IResult result = await BusinessRules.Run(IsNameExist(personelUserAdvertFollow.AdvertId, personelUserAdvertFollow.PersonelUserId));

            if (result != null)
            {
                return result;
            }
            await _personelUserAdvertFollowDal.AddAsync(personelUserAdvertFollow);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Terminate(PersonelUserAdvertFollow personelUserAdvertFollow)
        {
            await _personelUserAdvertFollowDal.Terminate(personelUserAdvertFollow);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertFollow>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<PersonelUserAdvertFollow>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAdvertFollow>>(await _personelUserAdvertFollowDal.GetAll(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserAdvertFollow?>> GetById(string id)
        {

            return new SuccessDataResult<PersonelUserAdvertFollow?>(await _personelUserAdvertFollowDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertFollow>>> GetAllByCompanyId(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertFollow>>(await _personelUserAdvertFollowDal.GetAll(c => c.CompanyUserId == id), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertFollow>>> GetAllByPersonelId(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertFollow>>(await _personelUserAdvertFollowDal.GetAll(p => p.PersonelUserId == id), Messages.SuccessListed);
        }



        //DTO Methods

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertFollowDTO>>> GetAllDTO(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertFollowDTO>>(await _personelUserAdvertFollowDal.GetAllDTO(), Messages.SuccessListed);


        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertFollowDTO>>> GetAllByAdvertIdDTO(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertFollowDTO>>(await _personelUserAdvertFollowDal.GetAllByAdvertIdDTO(id), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserAdvertFollowDTO>>> GetAllByPersonelIdDTO(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertFollowDTO>>(await _personelUserAdvertFollowDal.GetAllByPersonelIdDTO(id), Messages.SuccessListed);
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string advertId, string personelUserId)
        {
            var result = await _personelUserAdvertFollowDal.GetAll(c => c.AdvertId == advertId && c.PersonelUserId == personelUserId);

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
