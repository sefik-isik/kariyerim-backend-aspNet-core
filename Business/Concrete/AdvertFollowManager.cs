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
        public IResult Add(PersonelUserAdvertFollow personelUserAdvertFollow)
        {
            _personelUserAdvertFollowDal.AddAsync(personelUserAdvertFollow);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Terminate(PersonelUserAdvertFollow personelUserAdvertFollow)
        {
            _personelUserAdvertFollowDal.Terminate(personelUserAdvertFollow);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertFollow>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<PersonelUserAdvertFollow>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAdvertFollow>>(_personelUserAdvertFollowDal.GetAll().OrderBy(s => s.AdvertId).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserAdvertFollow> GetById(string id)
        {

            return new SuccessDataResult<PersonelUserAdvertFollow>(_personelUserAdvertFollowDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertFollow>> GetAllByCompanyId(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertFollow>>(_personelUserAdvertFollowDal.GetAll(c => c.CompanyUserId == id).OrderBy(s => s.AdvertId).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertFollow>> GetAllByPersonelId(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertFollow>>(_personelUserAdvertFollowDal.GetAll(p => p.PersonelUserId == id).OrderBy(s => s.AdvertId).ToList());
        }



        //DTO Methods

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertFollowDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<PersonelUserAdvertFollowDTO>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAdvertFollowDTO>>(_personelUserAdvertFollowDal.GetAllDTO().OrderBy(s => s.AdvertId).ToList());
            }

            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertFollowDTO>> GetAllByCompanyIdDTO(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertFollowDTO>>(_personelUserAdvertFollowDal.GetAllByCompanyIdDTO(id).OrderBy(s => s.AdvertId).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertFollowDTO>> GetAllByPersonelIdDTO(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertFollowDTO>>(_personelUserAdvertFollowDal.GetAllByPersonelIdDTO(id).OrderBy(s => s.AdvertId).ToList());
        }
    }
}
