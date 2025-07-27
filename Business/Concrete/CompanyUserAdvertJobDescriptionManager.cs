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
        public IResult Add(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            if (_userService.GetById(companyUserAdvertJobDescription.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserAdvertJobDescriptionDal.AddAsync(companyUserAdvertJobDescription);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        public IResult Update(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            if (_userService.GetById(companyUserAdvertJobDescription.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserAdvertJobDescriptionDal.UpdateAsync(companyUserAdvertJobDescription);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            if (_userService.GetById(companyUserAdvertJobDescription.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserAdvertJobDescriptionDal.Delete(companyUserAdvertJobDescription);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public IResult Terminate(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            _companyUserAdvertJobDescriptionDal.Terminate(companyUserAdvertJobDescription);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvertJobDescription>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescription>>(_companyUserAdvertJobDescriptionDal.GetAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertId).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescription>>(_companyUserAdvertJobDescriptionDal.GetAll().OrderBy(s => s.AdvertId).ToList(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvertJobDescription>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescription>>(_companyUserAdvertJobDescriptionDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertId).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescription>>(_companyUserAdvertJobDescriptionDal.GetDeletedAll().OrderBy(s => s.AdvertId).ToList(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUserAdvertJobDescription> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserAdvertJobDescription>(_companyUserAdvertJobDescriptionDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<CompanyUserAdvertJobDescription>(_companyUserAdvertJobDescriptionDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvertJobDescriptionDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescriptionDTO>>(_companyUserAdvertJobDescriptionDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.Id && c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertId).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescriptionDTO>>(_companyUserAdvertJobDescriptionDal.GetAllDTO().OrderBy(s => s.AdvertId).ToList(), Messages.SuccessListed);
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvertJobDescriptionDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescriptionDTO>>(_companyUserAdvertJobDescriptionDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.Id && c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertId).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertJobDescriptionDTO>>(_companyUserAdvertJobDescriptionDal.GetDeletedAllDTO().OrderBy(s => s.AdvertId).ToList(), Messages.SuccessListed);
            }

        }
    }
}
