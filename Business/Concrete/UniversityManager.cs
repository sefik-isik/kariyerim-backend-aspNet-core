using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UniversityManager: IUniversityService
    {
        IUniversityDal _universityDal;
       
        public UniversityManager(IUniversityDal universityDal)
        {
            _universityDal = universityDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(University university)
        {
            IResult result = BusinessRules.Run(
                IsNameExist(university.UniversityName),
                IsWebAddressExist(university.WebAddress),
                IsWebNewsAddressExist(university.WebNewsAddress),
                IsYouTubeEmbedAddressExist(university.YouTubeEmbedAddress),
                IsAddressExist(university.Address),
                IsFacebookAddressExist(university.FacebookAddress),
                IsInstagramAddressExist(university.InstagramAddress),
                IsXAddressExist(university.XAddress),
                IsYouTubeAddressExist(university.YouTubeAddress)
                );

            if (result != null)
            {
                return result;
            }
            _universityDal.AddAsync(university);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(University university)
        {
            _universityDal.UpdateAsync(university);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(University university)
        {
            _universityDal.Delete(university);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Terminate(University university)
        {
            _universityDal.TerminateSubDatas(university.Id);
            _universityDal.Terminate(university);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<University>> GetAll()
        {
            return new SuccessDataResult<List<University>>(_universityDal.GetAll().OrderBy(s => s.UniversityName).ToList());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<University>> GetDeletedAll()
        {
            return new SuccessDataResult<List<University>>(_universityDal.GetDeletedAll().OrderBy(s => s.UniversityName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<University> GetById(string id)
        {
            return new SuccessDataResult<University>(_universityDal.Get(u=>u.Id == id));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<UniversityDTO>>(_universityDal.GetAllDTO().OrderBy(s => s.UniversityName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityDTO>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<UniversityDTO>>(_universityDal.GetDeletedAllDTO().OrderBy(s => s.UniversityName).ToList());
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _universityDal.GetAll(c => c.UniversityName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult IsWebAddressExist(string entityName)
        {
            var result = _universityDal.GetAll(c => c.WebAddress.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult IsWebNewsAddressExist(string entityName)
        {
            var result = _universityDal.GetAll(c => c.WebNewsAddress.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult IsYouTubeEmbedAddressExist(string entityName)
        {
            var result = _universityDal.GetAll(c => c.YouTubeEmbedAddress.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult IsAddressExist(string entityName)
        {
            var result = _universityDal.GetAll(c => c.Address.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult IsFacebookAddressExist(string entityName)
        {
            var result = _universityDal.GetAll(c => c.FacebookAddress.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult IsInstagramAddressExist(string entityName)
        {
            var result = _universityDal.GetAll(c => c.InstagramAddress.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult IsXAddressExist(string entityName)
        {
            var result = _universityDal.GetAll(c => c.XAddress.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult IsYouTubeAddressExist(string entityName)
        {
            var result = _universityDal.GetAll(c => c.YouTubeAddress.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
