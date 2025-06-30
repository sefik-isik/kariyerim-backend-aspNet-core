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
    public class CompanyFollowManager : ICompanyFollowService
    {
        ICompanyFollowDal _companyFollowDal;
        IUserService _userService;
        public CompanyFollowManager(ICompanyFollowDal companyFollowDal, IUserService userService)
        {
            _companyFollowDal = companyFollowDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public IResult Add(CompanyFollow companyFollow)
        {
            _companyFollowDal.AddAsync(companyFollow);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Terminate(CompanyFollow companyFollow)
        {
            _companyFollowDal.Terminate(companyFollow);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyFollow>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<CompanyFollow>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<CompanyFollow>>(_companyFollowDal.GetAll().OrderBy(s => s.Id).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyFollow> GetById(string id)
        {

            return new SuccessDataResult<CompanyFollow>(_companyFollowDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyFollow>> GetAllByCompanyId(string id)
        {
            return new SuccessDataResult<List<CompanyFollow>>(_companyFollowDal.GetAll(c => c.CompanyUserId == id).OrderBy(s => s.CompanyUserId).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyFollow>> GetAllByPersonelId(string id)
        {
            return new SuccessDataResult<List<CompanyFollow>>(_companyFollowDal.GetAll(p => p.PersonelUserId == id).OrderBy(s => s.PersonelUserId).ToList());
        }



        //DTO Methods

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyFollowDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<CompanyFollowDTO>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<CompanyFollowDTO>>(_companyFollowDal.GetAllDTO().OrderBy(s => s.Id).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyFollowDTO>> GetAllByCompanyIdDTO(string id)
        {
            return new SuccessDataResult<List<CompanyFollowDTO>>(_companyFollowDal.GetAllByCompanyIdDTO(id).OrderBy(s => s.CompanyUserId).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyFollowDTO>> GetAllByPersonelIdDTO(string id)
        {
            return new SuccessDataResult<List<CompanyFollowDTO>>(_companyFollowDal.GetAllByPersonelIdDTO(id).OrderBy(s => s.PersonelUserId).ToList());
        }
    }
}
