using Core.DataAccess.EntityFramework;
using Core.Utilities.Business.Constans;
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
        public List<PersonelUserCvEducationDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCvEducations in context.PersonelUserCvEducations
                             join personelUserCv in context.PersonelUserCvs on personelUserCvEducations.CvId equals personelUserCv.Id
                             join personelUsers in context.PersonelUsers on personelUserCvEducations.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join university in context.Universities on personelUserCvEducations.UniversityId equals university.Id
                             join department in context.UniversityDepartments on personelUserCvEducations.DepartmentId equals department.Id
                             join faculty in context.Faculties on personelUserCvEducations.FacultyId equals faculty.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCvEducations.DeletedDate == null && users.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCv.DeletedDate == null

                             select new PersonelUserCvEducationDTO
                             {
                                 Id = personelUserCvEducations.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 Code = users.Code,
                                 PersonelUserId = personelUsers.Id,
                                 CvId = personelUserCv.Id,
                                 EducationInfo = personelUserCvEducations.EducationInfo,
                                 UniversityId = university.Id,
                                 UniversityName = university.UniversityName,
                                 DepartmentId = department.Id,
                                 DepartmentName = department.DepartmentName,
                                 StartDate = personelUserCvEducations.StartDate,
                                 EndDate = personelUserCvEducations.EndDate,
                                 FacultyId = faculty.Id,
                                 FacultyName = faculty.FacultyName,
                                 Detail = personelUserCvEducations.Detail,
                                 CreatedDate = personelUserCvEducations.CreatedDate,
                                 UpdatedDate = personelUserCvEducations.UpdatedDate,
                                 DeletedDate = personelUserCvEducations.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<PersonelUserCvEducationDTO> GetAllDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCvEducations in context.PersonelUserCvEducations
                             join personelUserCv in context.PersonelUserCvs on personelUserCvEducations.CvId equals personelUserCv.Id
                             join personelUsers in context.PersonelUsers on personelUserCvEducations.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join university in context.Universities on personelUserCvEducations.UniversityId equals university.Id
                             join department in context.UniversityDepartments on personelUserCvEducations.DepartmentId equals department.Id
                             join faculty in context.Faculties on personelUserCvEducations.FacultyId equals faculty.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCvEducations.DeletedDate != null && users.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCv.DeletedDate == null

                             select new PersonelUserCvEducationDTO
                             {
                                 Id = personelUserCvEducations.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 Code = users.Code,
                                 PersonelUserId = personelUsers.Id,
                                 CvId = personelUserCv.Id,
                                 EducationInfo = personelUserCvEducations.EducationInfo,
                                 UniversityId = university.Id,
                                 UniversityName = university.UniversityName,
                                 DepartmentId = department.Id,
                                 DepartmentName = department.DepartmentName,
                                 StartDate = personelUserCvEducations.StartDate,
                                 EndDate = personelUserCvEducations.EndDate,
                                 FacultyId = faculty.Id,
                                 FacultyName = faculty.FacultyName,
                                 Detail = personelUserCvEducations.Detail,
                                 CreatedDate = personelUserCvEducations.CreatedDate,
                                 UpdatedDate = personelUserCvEducations.UpdatedDate,
                                 DeletedDate = personelUserCvEducations.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
