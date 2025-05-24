using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class DepartmentDetailManager: IDepartmentDetailService
    {
        IDepartmentDetailDal _departmentDetailDal;

        public DepartmentDetailManager(IDepartmentDetailDal departmentDetailDal)
        {
            _departmentDetailDal = departmentDetailDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(DepartmentDetail departmentDetail)
        {
            _departmentDetailDal.Add(departmentDetail);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(DepartmentDetail departmentDetail)
        {
            _departmentDetailDal.Update(departmentDetail);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(DepartmentDetail departmentDetail)
        {
            _departmentDetailDal.Delete(departmentDetail);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<DepartmentDetail>> GetAll()
        {
            return new SuccessDataResult<List<DepartmentDetail>>(_departmentDetailDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<DepartmentDetail>> GetDeletedAll()
        {
            return new SuccessDataResult<List<DepartmentDetail>>(_departmentDetailDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<DepartmentDetail> GetById(int id)
        {
            return new SuccessDataResult<DepartmentDetail>(_departmentDetailDal.Get(r => r.Id == id));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<DepartmentDetailDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<DepartmentDetailDTO>>(_departmentDetailDal.GetAllDTO().OrderBy(s => s.DepartmentName).ToList());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<DepartmentDetailDTO>> GetDeletedAllDTO()
        {
            return new SuccessDataResult<List<DepartmentDetailDTO>>(_departmentDetailDal.GetDeletedAllDTO().OrderBy(s => s.DepartmentName).ToList());
        }
    }
}
