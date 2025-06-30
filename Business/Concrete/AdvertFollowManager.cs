using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
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
    public class AdvertFollowManager : IAdvertFollowService
    {
        IAdvertFollowDal _advertFollowDal;
        IUserService _userService;

        public AdvertFollowManager(IAdvertFollowDal advertFollowDal, IUserService userService)
        {
            _advertFollowDal = advertFollowDal;
            _userService = userService;

        }

        [SecuredOperation("admin,user")]
        public IResult Add(AdvertFollow advertFollow)
        {
            _advertFollowDal.AddAsync(advertFollow);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Terminate(AdvertFollow advertFollow)
        {
            _advertFollowDal.Terminate(advertFollow);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertFollow>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<AdvertFollow>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<AdvertFollow>>(_advertFollowDal.GetAll().OrderBy(s => s.AdvertId).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<AdvertFollow> GetById(string id)
        {

            return new SuccessDataResult<AdvertFollow>(_advertFollowDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertFollow>> GetAllByCompanyId(string id)
        {
            return new SuccessDataResult<List<AdvertFollow>>(_advertFollowDal.GetAll(c => c.CompanyUserId == id).OrderBy(s => s.AdvertId).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertFollow>> GetAllByPersonelId(string id)
        {
            return new SuccessDataResult<List<AdvertFollow>>(_advertFollowDal.GetAll(p => p.PersonelUserId == id).OrderBy(s => s.AdvertId).ToList());
        }



        //DTO Methods

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertFollowDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<AdvertFollowDTO>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<AdvertFollowDTO>>(_advertFollowDal.GetAllDTO().OrderBy(s => s.AdvertId).ToList());
            }

            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertFollowDTO>> GetAllByCompanyIdDTO(string id)
        {
            return new SuccessDataResult<List<AdvertFollowDTO>>(_advertFollowDal.GetAllByCompanyIdDTO(id).OrderBy(s => s.AdvertId).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertFollowDTO>> GetAllByPersonelIdDTO(string id)
        {
            return new SuccessDataResult<List<AdvertFollowDTO>>(_advertFollowDal.GetAllByPersonelIdDTO(id).OrderBy(s => s.AdvertId).ToList());
        }
    }
}
