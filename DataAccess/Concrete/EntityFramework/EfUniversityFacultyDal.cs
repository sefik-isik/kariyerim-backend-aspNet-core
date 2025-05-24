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
    public class EfUniversityFacultyDal : EfEntityRepositoryBase<UniversityFaculty, KariyerimContext>, IUniversityFacultyDal
    {
        public List<UniversityFacultyDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityFaculties in context.UniversityFaculties
                             join universities in context.Universities on universityFaculties.UniversityId equals universities.Id
                             join faculties in context.Faculties on universityFaculties.FacultyId equals faculties.Id
                             where universityFaculties.DeletedDate == null && universities.DeletedDate == null && faculties.DeletedDate == null

                             select new UniversityFacultyDTO
                             {
                                 Id = universityFaculties.Id,
                                 UniversityId = universityFaculties.UniversityId,
                                 UniversityName = universities.UniversityName,
                                 FacultyId = universityFaculties.FacultyId,
                                 FacultyName = faculties.FacultyName,
                                 CreatedDate = universityFaculties.CreatedDate,
                                 UpdatedDate = universityFaculties.UpdatedDate,
                                 DeletedDate = universityFaculties.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<UniversityFacultyDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityFaculties in context.UniversityFaculties
                             join universities in context.Universities on universityFaculties.UniversityId equals universities.Id
                             join faculties in context.Faculties on universityFaculties.FacultyId equals faculties.Id
                             where universityFaculties.DeletedDate != null && universities.DeletedDate == null && faculties.DeletedDate == null

                             select new UniversityFacultyDTO
                             {
                                 Id = universityFaculties.Id,
                                 UniversityId = universityFaculties.UniversityId,
                                 UniversityName = universities.UniversityName,
                                 FacultyId = universityFaculties.FacultyId,
                                 FacultyName = faculties.FacultyName,
                                 CreatedDate = universityFaculties.CreatedDate,
                                 UpdatedDate = universityFaculties.UpdatedDate,
                                 DeletedDate = universityFaculties.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
