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
    public class CompanyUserAdvertCityManager : ICompanyUserAdvertCityService
    {
        ICompanyUserAdvertCityDal _companyUserAdvertCityDal;
        IUserService _userService;

        public CompanyUserAdvertCityManager(ICompanyUserAdvertCityDal companyUserAdvertCityDal, IUserService userService)
        {
            _companyUserAdvertCityDal = companyUserAdvertCityDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public IResult Add(CompanyUserAdvertCity companyUserAdvertCity)
        {
            if (_userService.GetById(companyUserAdvertCity.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserAdvertCityDal.AddAsync(companyUserAdvertCity);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(CompanyUserAdvertCity companyUserAdvertCity)
        {
            if (_userService.GetById(companyUserAdvertCity.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserAdvertCityDal.UpdateAsync(companyUserAdvertCity);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserAdvertCity companyUserAdvertCity)
        {
            if (_userService.GetById(companyUserAdvertCity.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserAdvertCityDal.Delete(companyUserAdvertCity);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Terminate(CompanyUserAdvertCity companyUserAdvertCity)
        {
            _companyUserAdvertCityDal.Terminate(companyUserAdvertCity);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvertCity>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertCity>>(_companyUserAdvertCityDal.GetAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertId).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertCity>>(_companyUserAdvertCityDal.GetAll().OrderBy(s => s.AdvertId).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvertCity>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertCity>>(_companyUserAdvertCityDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertId).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertCity>>(_companyUserAdvertCityDal.GetDeletedAll().OrderBy(s => s.AdvertId).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUserAdvertCity> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserAdvertCity>(_companyUserAdvertCityDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<CompanyUserAdvertCity>(_companyUserAdvertCityDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvertCityDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertCityDTO>>(_companyUserAdvertCityDal.GetAllDTO().FindAll(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertId).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertCityDTO>>(_companyUserAdvertCityDal.GetAllDTO().OrderBy(s => s.AdvertId).ToList());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvertCityDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertCityDTO>>(_companyUserAdvertCityDal.GetDeletedAllDTO().FindAll(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertId).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertCityDTO>>(_companyUserAdvertCityDal.GetDeletedAllDTO().OrderBy(s => s.AdvertId).ToList());
            }

        }
    }
}
