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
    public class EfPersonelUserCvEducationDal : EfEntityRepositoryBase<PersonelUserCvEducation, KariyerimContext>, IPersonelUserCvEducationDal
    {
        public List<PersonelUserCvEducationDTO> GetPersonelUserCvEducationDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from cvEducation in context.PersonelUserCvEducations
                             join personelUserCv in context.PersonelUserCvs on cvEducation.CvId equals personelUserCv.Id
                             join personelUsers in context.PersonelUsers on cvEducation.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join university in context.Universities on cvEducation.UniversityId equals university.Id
                             join department in context.UniversityDepartments on cvEducation.DepartmentId equals department.Id
                             join faculty in context.Faculties on cvEducation.FacultyId equals faculty.Id
                             where cvEducation.DeletedDate==null
                             select new PersonelUserCvEducationDTO
                             {
                                 Id = cvEducation.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 PersonelUserId = personelUsers.Id,
                                 CvId = personelUserCv.Id,
                                 EducationInfo = cvEducation.EducationInfo,
                                 UniversityId = university.Id,
                                 UniversityName = university.UniversityName,
                                 DepartmentId=department.Id,
                                 DepartmentName = department.DepartmentName,
                                 StartDate = cvEducation.StartDate,
                                 EndDate = cvEducation.EndDate,
                                 FacultyId=faculty.Id,
                                 FacultyName = faculty.FacultyName,
                                 Detail = cvEducation.Detail,
                                 CreatedDate = cvEducation.CreatedDate,
                                 UpdatedDate = cvEducation.UpdatedDate,
                                 DeletedDate = cvEducation.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<PersonelUserCvEducationDTO> GetPersonelUserCvEducationDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from cvEducation in context.PersonelUserCvEducations
                             join personelUserCv in context.PersonelUserCvs on cvEducation.CvId equals personelUserCv.Id
                             join personelUsers in context.PersonelUsers on cvEducation.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join university in context.Universities on cvEducation.UniversityId equals university.Id
                             join department in context.UniversityDepartments on cvEducation.DepartmentId equals department.Id
                             join faculty in context.Faculties on cvEducation.FacultyId equals faculty.Id
                             where cvEducation.DeletedDate != null
                             select new PersonelUserCvEducationDTO
                             {
                                 Id = cvEducation.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 PersonelUserId = personelUsers.Id,
                                 CvId = personelUserCv.Id,
                                 EducationInfo = cvEducation.EducationInfo,
                                 UniversityId = university.Id,
                                 UniversityName = university.UniversityName,
                                 DepartmentId = department.Id,
                                 DepartmentName = department.DepartmentName,
                                 StartDate = cvEducation.StartDate,
                                 EndDate = cvEducation.EndDate,
                                 FacultyId = faculty.Id,
                                 FacultyName = faculty.FacultyName,
                                 Detail = cvEducation.Detail,
                                 CreatedDate = cvEducation.CreatedDate,
                                 UpdatedDate = cvEducation.UpdatedDate,
                                 DeletedDate = cvEducation.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
