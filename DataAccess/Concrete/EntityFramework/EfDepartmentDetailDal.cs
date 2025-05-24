using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDetailDal : EfEntityRepositoryBase<DepartmentDetail, KariyerimContext>, IDepartmentDetailDal
    {
        public List<DepartmentDetailDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from departmentDetails in context.DepartmentDetails
                             join departments in context.Departments on departmentDetails.DepartmentId equals departments.Id

                             where departmentDetails.DeletedDate == null && departments.DeletedDate == null 

                             select new DepartmentDetailDTO
                             {
                                 Id = departmentDetails.Id,
                                 DepartmentId = departmentDetails.DepartmentId,
                                 DepartmentName = departments.DepartmentName,
                                 Title = departmentDetails.Title,
                                 Description = departmentDetails.Description,
                                 CreatedDate = departmentDetails.CreatedDate,
                                 UpdatedDate = departmentDetails.UpdatedDate,
                                 DeletedDate = departmentDetails.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<DepartmentDetailDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from departmentDetails in context.DepartmentDetails
                             join departments in context.Departments on departmentDetails.DepartmentId equals departments.Id

                             where departmentDetails.DeletedDate != null && departments.DeletedDate == null

                             select new DepartmentDetailDTO
                             {
                                 Id = departmentDetails.Id,
                                 DepartmentId = departmentDetails.DepartmentId,
                                 DepartmentName = departments.DepartmentName,
                                 Title = departmentDetails.Title,
                                 Description = departmentDetails.Description,
                                 CreatedDate = departmentDetails.CreatedDate,
                                 UpdatedDate = departmentDetails.UpdatedDate,
                                 DeletedDate = departmentDetails.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
