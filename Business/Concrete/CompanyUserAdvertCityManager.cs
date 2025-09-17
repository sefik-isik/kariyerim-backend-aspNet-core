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
        public async Task<IResult> Add(CompanyUserAdvertCity companyUserAdvertCity)
        {
            if (_userService.GetById(companyUserAdvertCity.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserAdvertCityDal.AddAsync(companyUserAdvertCity);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(CompanyUserAdvertCity companyUserAdvertCity)
        {
            if (_userService.GetById(companyUserAdvertCity.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserAdvertCityDal.UpdateAsync(companyUserAdvertCity);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(CompanyUserAdvertCity companyUserAdvertCity)
        {
            if (_userService.GetById(companyUserAdvertCity.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserAdvertCityDal.Delete(companyUserAdvertCity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(CompanyUserAdvertCity companyUserAdvertCity)
        {
            await _companyUserAdvertCityDal.Terminate(companyUserAdvertCity);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertCity>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertCity>>(await _companyUserAdvertCityDal.GetAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertCity>>(await _companyUserAdvertCityDal.GetAll(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertCity>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertCity>>(await _companyUserAdvertCityDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertCity>>(await _companyUserAdvertCityDal.GetDeletedAll(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUserAdvertCity?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserAdvertCity?>(await _companyUserAdvertCityDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<CompanyUserAdvertCity?>(await _companyUserAdvertCityDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertCityDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var allDtos = await _companyUserAdvertCityDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertCityDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList().Where(c => c.UserId == userAdminDTO.UserId).OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertCityDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }

        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertCityDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var allDtos = await _companyUserAdvertCityDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertCityDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList().FindAll(c => c.UserId == userAdminDTO.Id && c.UserId == userAdminDTO.UserId).OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertCityDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertCityDTO>>> GetAllByIdDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var allDtos = await _companyUserAdvertCityDal.GetAllByIdDTO(userAdminDTO.Id);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertCityDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList().Where(c => c.UserId == userAdminDTO.UserId).OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertCityDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }

        }
    }
}
