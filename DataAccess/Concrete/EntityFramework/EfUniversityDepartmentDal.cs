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
                var result = from universityDepartments in context.UniversityDepartments
                             join universities in context.Universities on universityDepartments.UniversityId equals universities.Id
                             join faculties in context.Faculties on universityDepartments.FacultyId equals faculties.Id
                             join departments in context.Departments on universityDepartments.DepartmentId equals departments.Id

                             where universityDepartments.DeletedDate == null && universities.DeletedDate == null &&  faculties.DeletedDate == null && departments.DeletedDate == null

                             select new UniversityDepartmentDTO
                             {
                                 Id = universityDepartments.Id,
                                 UniversityId = universities.Id,
                                 UniversityName = universities.UniversityName,
                                 FacultyId = faculties.Id,
                                 FacultyName = faculties.FacultyName,
                                 DepartmentId = departments.Id,
                                 DepartmentName = departments.DepartmentName,
                                 CreatedDate = universityDepartments.CreatedDate,
                                 UpdatedDate = universityDepartments.UpdatedDate,
                                 DeletedDate = universityDepartments.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<UniversityDepartmentDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityDepartments in context.UniversityDepartments
                             join universities in context.Universities on universityDepartments.UniversityId equals universities.Id
                             join faculties in context.Faculties on universityDepartments.FacultyId equals faculties.Id
                             join departments in context.Departments on universityDepartments.DepartmentId equals departments.Id

                             where universityDepartments.DeletedDate != null && universities.DeletedDate == null && faculties.DeletedDate == null && departments.DeletedDate == null

                             select new UniversityDepartmentDTO
                             {
                                 Id = universityDepartments.Id,
                                 UniversityId = universities.Id,
                                 UniversityName = universities.UniversityName,
                                 FacultyId = faculties.Id,
                                 FacultyName = faculties.FacultyName,
                                 DepartmentId = departments.Id,
                                 DepartmentName = departments.DepartmentName,
                                 CreatedDate = universityDepartments.CreatedDate,
                                 UpdatedDate = universityDepartments.UpdatedDate,
                                 DeletedDate = universityDepartments.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
