using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDepartmentDetailService
    {
        IResult Add(DepartmentDetail departmentDetail);
        IResult Update(DepartmentDetail departmentDetail);
        IResult Delete(DepartmentDetail departmentDetail);
        IDataResult<List<DepartmentDetail>> GetAll();
        IDataResult<List<DepartmentDetail>> GetDeletedAll();
        IDataResult<DepartmentDetail> GetById(int id);

        //DTO
        IDataResult<List<DepartmentDetailDTO>> GetAllDTO();
        IDataResult<List<DepartmentDetailDTO>> GetDeletedAllDTO();
    }
}
