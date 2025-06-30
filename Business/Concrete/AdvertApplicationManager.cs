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
    public class AdvertApplicationManager : IAdvertApplicationService
    {
        IAdvertApplicationDal _advertApplicationDal;
        IUserService _userService;
        public AdvertApplicationManager(IAdvertApplicationDal advertApplicationDal, IUserService userService)
        {
            _advertApplicationDal = advertApplicationDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public IResult Add(AdvertApplication advertApplicationDTO)
        {
            _advertApplicationDal.AddAsync(advertApplicationDTO);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Terminate(AdvertApplication advertApplicationDTO)
        {
            _advertApplicationDal.Terminate(advertApplicationDTO);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertApplication>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<AdvertApplication>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<AdvertApplication>>(_advertApplicationDal.GetAll().OrderBy(s => s.AdvertId).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<AdvertApplication> GetById(string id)
        {

            return new SuccessDataResult<AdvertApplication>(_advertApplicationDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertApplication>> GetAllByCompanyId(string id)
        {
            return new SuccessDataResult<List<AdvertApplication>>(_advertApplicationDal.GetAll(c => c.CompanyUserId == id).OrderBy(s => s.AdvertId).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertApplication>> GetAllByPersonelId(string id)
        {
            return new SuccessDataResult<List<AdvertApplication>>(_advertApplicationDal.GetAll(p => p.PersonelUserId == id).OrderBy(s => s.AdvertId).ToList());
        }



        //DTO Methods

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertApplicationDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<AdvertApplicationDTO>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<AdvertApplicationDTO>>(_advertApplicationDal.GetAllDTO().OrderBy(s => s.AdvertId).ToList());
            }


        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertApplicationDTO>> GetAllByCompanyIdDTO(string id)
        {
            return new SuccessDataResult<List<AdvertApplicationDTO>>(_advertApplicationDal.GetAllByCompanyIdDTO(id).OrderBy(s => s.AdvertId).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<AdvertApplicationDTO>> GetAllByPersonelIdDTO(string id)
        {
            return new SuccessDataResult<List<AdvertApplicationDTO>>(_advertApplicationDal.GetAllByPersonelIdDTO(id).OrderBy(s => s.AdvertId).ToList());
        }
    }
}
