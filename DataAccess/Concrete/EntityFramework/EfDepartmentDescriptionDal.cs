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
    public class EfDepartmentDescriptionDal : EfEntityRepositoryBase<DepartmentDescription, KariyerimContext>, IDepartmentDescriptionDal
    {
        public List<DepartmentDescriptionDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from departmentDescriptions in context.DepartmentDescriptions
                             join departments in context.Departments on departmentDescriptions.DepartmentId equals departments.Id

                             where departmentDescriptions.DeletedDate == null 

                             select new DepartmentDescriptionDTO
                             {
                                 Id = departmentDescriptions.Id,
                                 DepartmentId = departments.Id,
                                 DepartmentName = departments.DepartmentName,
                                 Title = departmentDescriptions.Title,
                                 Description = departmentDescriptions.Description,
                                 CreatedDate = departmentDescriptions.CreatedDate,
                                 UpdatedDate = departmentDescriptions.UpdatedDate,
                                 DeletedDate = departmentDescriptions.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<DepartmentDescriptionDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from departmentDescriptions in context.DepartmentDescriptions
                             join departments in context.Departments on departmentDescriptions.DepartmentId equals departments.Id

                             where departmentDescriptions.DeletedDate != null

                             select new DepartmentDescriptionDTO
                             {
                                 Id = departmentDescriptions.Id,
                                 DepartmentId = departments.Id,
                                 DepartmentName = departments.DepartmentName,
                                 Title = departmentDescriptions.Title,
                                 Description = departmentDescriptions.Description,
                                 CreatedDate = departmentDescriptions.CreatedDate,
                                 UpdatedDate = departmentDescriptions.UpdatedDate,
                                 DeletedDate = departmentDescriptions.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
