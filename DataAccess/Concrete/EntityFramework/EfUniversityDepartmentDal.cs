using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfUniversityDepartmentDal : EfEntityRepositoryBase<UniversityDepartment, KariyerimContext>,IUniversityDepartmentDal
    {
        public List<UniversityDepartmentDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityDepartment in context.UniversityDepartments
                             join university in context.Universities on universityDepartment.UniversityId equals university.Id

                             where universityDepartment.DeletedDate == null 

                             select new UniversityDepartmentDTO
                             {
                                 Id = universityDepartment.Id,
                                 UniversityId = university.Id,
                                 UniversityName = university.UniversityName,
                                 DepartmentName = universityDepartment.DepartmentName,
                                 CreatedDate = universityDepartment.CreatedDate,
                                 UpdatedDate = universityDepartment.UpdatedDate,
                                 DeletedDate = universityDepartment.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<UniversityDepartmentDTO> GetAllDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityDepartment in context.UniversityDepartments
                             join university in context.Universities on universityDepartment.UniversityId equals university.Id

                             where universityDepartment.DeletedDate != null 

                             select new UniversityDepartmentDTO
                             {
                                 Id = universityDepartment.Id,
                                 UniversityId = university.Id,
                                 UniversityName = university.UniversityName,
                                 DepartmentName = universityDepartment.DepartmentName,
                                 CreatedDate = universityDepartment.CreatedDate,
                                 UpdatedDate = universityDepartment.UpdatedDate,
                                 DeletedDate = universityDepartment.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
