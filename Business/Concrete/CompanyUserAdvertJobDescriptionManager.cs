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
    public class CompanyUserAdvertJobDescriptionManager : ICompanyUserAdvertJobDescriptionService
    {
        ICompanyUserAdvertJobDescriptionDal _companyUserAdvertJobDescriptionDal;
        IUserService _userService;

        public CompanyUserAdvertJobDescriptionManager(ICompanyUserAdvertJobDescriptionDal companyUserAdvertJobDescriptionDal, IUserService userService)
        {
            _companyUserAdvertJobDescriptionDal = companyUserAdvertJobDescriptionDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            if (_userService.GetById(companyUserAdvertJobDescription.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserAdvertJobDescriptionDal.AddAsync(companyUserAdvertJobDescription);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            if (_userService.GetById(companyUserAdvertJobDescription.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserAdvertJobDescriptionDal.UpdateAsync(companyUserAdvertJobDescription);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            if (_userService.GetById(companyUserAdvertJobDescription.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserAdvertJobDescriptionDal.Delete(companyUserAdvertJobDescription);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            await _companyUserAdvertJobDescriptionDal.Terminate(companyUserAdvertJobDescription);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertJobDescription>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescription>>(await _companyUserAdvertJobDescriptionDal.GetAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescription>>(await _companyUserAdvertJobDescriptionDal.GetAll(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertJobDescription>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescription>>(await _companyUserAdvertJobDescriptionDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescription>>(await _companyUserAdvertJobDescriptionDal.GetDeletedAll(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUserAdvertJobDescription?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserAdvertJobDescription?>(await _companyUserAdvertJobDescriptionDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<CompanyUserAdvertJobDescription?>(await  _companyUserAdvertJobDescriptionDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertJobDescriptionDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _companyUserAdvertJobDescriptionDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescriptionDTO>>(alldto.OrderBy(o => o.CompanyUserName).ToList().FindAll(c => c.UserId == userAdminDTO.Id && c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescriptionDTO>>(alldto.OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }

        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAdvertJobDescriptionDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _companyUserAdvertJobDescriptionDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescriptionDTO>>(alldto.OrderBy(o => o.CompanyUserName).ToList().FindAll(c => c.UserId == userAdminDTO.Id && c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescriptionDTO>>(alldto.OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }

        }

        public async Task<IDataResult<List<CompanyUserAdvertJobDescriptionDTO>>> GetAllByIdDTO(string id)
        {
            return new SuccessDataResult<List<CompanyUserAdvertJobDescriptionDTO>>(await _companyUserAdvertJobDescriptionDal.GetAllByIdDTO(id));
        }
    }
}
