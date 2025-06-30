using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
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

    }
}
