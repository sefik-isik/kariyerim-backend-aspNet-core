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
                             join universities in context.Universities on personelUserCvEducations.UniversityId equals universities.Id
                             join departments in context.Departments on personelUserCvEducations.DepartmentId equals departments.Id
                             join faculties in context.Faculties on personelUserCvEducations.FacultyId equals faculties.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCvEducations.DeletedDate == null && users.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCv.DeletedDate == null

                             select new PersonelUserCvEducationDTO
                             {
                                 Id = personelUserCvEducations.Id,
                                 UserId = users.Id,
                                 PersonelUserId = personelUsers.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CvId = personelUserCv.Id,
                                 CvName=personelUserCv.CvName,
                                 Abandonment = personelUserCvEducations.Abandonment,
                                 EducationInfo = personelUserCvEducations.EducationInfo,
                                 UniversityId = universities.Id,
                                 UniversityName = universities.UniversityName,
                                 DepartmentId = departments.Id,
                                 DepartmentName = departments.DepartmentName,
                                 StartDate = personelUserCvEducations.StartDate,
                                 EndDate = personelUserCvEducations.EndDate,
                                 FacultyId = faculties.Id,
                                 FacultyName = faculties.FacultyName,
                                 Detail = personelUserCvEducations.Detail,
                                 CreatedDate = personelUserCvEducations.CreatedDate,
                                 UpdatedDate = personelUserCvEducations.UpdatedDate,
                                 DeletedDate = personelUserCvEducations.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<PersonelUserCvEducationDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserCvEducations in context.PersonelUserCvEducations
                             join personelUserCv in context.PersonelUserCvs on personelUserCvEducations.CvId equals personelUserCv.Id
                             join personelUsers in context.PersonelUsers on personelUserCvEducations.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join universities in context.Universities on personelUserCvEducations.UniversityId equals universities.Id
                             join departments in context.Departments on personelUserCvEducations.DepartmentId equals departments.Id
                             join faculties in context.Faculties on personelUserCvEducations.FacultyId equals faculties.Id

                             where users.Code == UserCodes.PersonelUserCode &&
                             personelUserCvEducations.DeletedDate != null && users.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCv.DeletedDate == null

                             select new PersonelUserCvEducationDTO
                             {
                                 Id = personelUserCvEducations.Id,
                                 UserId = users.Id,
                                 PersonelUserId = personelUsers.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CvId = personelUserCv.Id,
                                 CvName = personelUserCv.CvName,
                                 Abandonment = personelUserCvEducations.Abandonment,
                                 EducationInfo = personelUserCvEducations.EducationInfo,
                                 UniversityId = universities.Id,
                                 UniversityName = universities.UniversityName,
                                 DepartmentId = departments.Id,
                                 DepartmentName = departments.DepartmentName,
                                 StartDate = personelUserCvEducations.StartDate,
                                 EndDate = personelUserCvEducations.EndDate,
                                 FacultyId = faculties.Id,
                                 FacultyName = faculties.FacultyName,
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
