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
    public class PersonelUserAdvertApplicationManager : IPersonelUserAdvertApplicationService
    {
        IPersonelUserAdvertApplicationDal _personelUseradvertApplicationDal;
        IUserService _userService;
        public PersonelUserAdvertApplicationManager(IPersonelUserAdvertApplicationDal personelUseradvertApplicationDal, IUserService userService)
        {
            _personelUseradvertApplicationDal = personelUseradvertApplicationDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserAdvertApplication personelUseradvertApplicationDTO)
        {
            _personelUseradvertApplicationDal.AddAsync(personelUseradvertApplicationDTO);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Terminate(PersonelUserAdvertApplication personelUseradvertApplicationDTO)
        {
            _personelUseradvertApplicationDal.Terminate(personelUseradvertApplicationDTO);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertApplication>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<PersonelUserAdvertApplication>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAdvertApplication>>(_personelUseradvertApplicationDal.GetAll().OrderBy(s => s.AdvertId).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserAdvertApplication> GetById(string id)
        {

            return new SuccessDataResult<PersonelUserAdvertApplication>(_personelUseradvertApplicationDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertApplication>> GetAllByCompanyId(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertApplication>>(_personelUseradvertApplicationDal.GetAll(c => c.CompanyUserId == id).OrderBy(s => s.AdvertId).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertApplication>> GetAllByPersonelId(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertApplication>>(_personelUseradvertApplicationDal.GetAll(p => p.PersonelUserId == id).OrderBy(s => s.AdvertId).ToList());
        }



        //DTO Methods

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertApplicationDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<PersonelUserAdvertApplicationDTO>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAdvertApplicationDTO>>(_personelUseradvertApplicationDal.GetAllDTO().OrderBy(s => s.AdvertId).ToList());
            }


        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertApplicationDTO>> GetAllByCompanyIdDTO(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertApplicationDTO>>(_personelUseradvertApplicationDal.GetAllByCompanyIdDTO(id).OrderBy(s => s.AdvertId).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAdvertApplicationDTO>> GetAllByPersonelIdDTO(string id)
        {
            return new SuccessDataResult<List<PersonelUserAdvertApplicationDTO>>(_personelUseradvertApplicationDal.GetAllByPersonelIdDTO(id).OrderBy(s => s.AdvertId).ToList());
        }
    }
}
