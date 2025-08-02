using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UniversityFacultyManager : IUniversityFacultyService
    {
        IUniversityFacultyDal _universityFacultyDal;

        public UniversityFacultyManager(IUniversityFacultyDal universityFacultyDal)
        {
            _universityFacultyDal = universityFacultyDal;
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Add(UniversityFaculty universityFaculty)
        {
            IResult result = await BusinessRules.Run(IsNameExist(universityFaculty.FacultyName));

            if (result != null)
            {
                return result;
            }
            await _universityFacultyDal.AddAsync(universityFaculty);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(UniversityFaculty universityFaculty)
        {
            await _universityFacultyDal.UpdateAsync(universityFaculty);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(UniversityFaculty universityFaculty)
        {
            await _universityFacultyDal.Delete(universityFaculty);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(UniversityFaculty universityFaculty)
        {
            await _universityFacultyDal.Terminate(universityFaculty);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityFaculty>>> GetAll()
        {
            var result = await _universityFacultyDal.GetAll();
            result = result.OrderBy(x => x.FacultyName).ToList();
            return new SuccessDataResult<List<UniversityFaculty>>(result, Messages.SuccessListed);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityFaculty>>> GetDeletedAll()
        {
            var result = await _universityFacultyDal.GetDeletedAll();
            result = result.OrderBy(x => x.FacultyName).ToList();
            return new SuccessDataResult<List<UniversityFaculty>>(result, Messages.SuccessListed);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<UniversityFaculty?>> GetById(string id)
        {
            return new SuccessDataResult<UniversityFaculty?>(await _universityFacultyDal.Get(l => l.Id == id));
        }
        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _universityFacultyDal.GetAll(c => c.FacultyName.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
