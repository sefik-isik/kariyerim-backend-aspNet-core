using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUniversityDepartmentDescriptionDal : EfEntityRepositoryBase<UniversityDepartmentDescription, KariyerimContext>, IUniversityDepartmentDescriptionDal
    {
        public async Task<List<UniversityDepartmentDescriptionDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityDepartmentDescriptions in context.UniversityDepartmentDescriptions
                             join universityDepartments in context.UniversityDepartments on universityDepartmentDescriptions.DepartmentId equals universityDepartments.Id

                             where universityDepartmentDescriptions.DeletedDate == null

                             select new UniversityDepartmentDescriptionDTO
                             {
                                 Id = universityDepartmentDescriptions.Id,
                                 DepartmentId = universityDepartmentDescriptions.DepartmentId,
                                 DepartmentName = universityDepartments.DepartmentName,
                                 Title = universityDepartmentDescriptions.Title,
                                 Description = universityDepartmentDescriptions.Description,
                                 CreatedDate = universityDepartmentDescriptions.CreatedDate,
                                 UpdatedDate = universityDepartmentDescriptions.UpdatedDate,
                                 DeletedDate = universityDepartmentDescriptions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<UniversityDepartmentDescriptionDTO>> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityDepartmentDescriptions in context.UniversityDepartmentDescriptions
                             join universityDepartments in context.UniversityDepartments on universityDepartmentDescriptions.DepartmentId equals universityDepartments.Id

                             where universityDepartmentDescriptions.DeletedDate != null

                             select new UniversityDepartmentDescriptionDTO
                             {
                                 Id = universityDepartmentDescriptions.Id,
                                 DepartmentId = universityDepartmentDescriptions.DepartmentId,
                                 DepartmentName = universityDepartments.DepartmentName,
                                 Title = universityDepartmentDescriptions.Title,
                                 Description = universityDepartmentDescriptions.Description,
                                 CreatedDate = universityDepartmentDescriptions.CreatedDate,
                                 UpdatedDate = universityDepartmentDescriptions.UpdatedDate,
                                 DeletedDate = universityDepartmentDescriptions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<UniversityDepartmentDescriptionDTO>> GetAllByUniversityDepartmentIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityDepartmentDescriptions in context.UniversityDepartmentDescriptions
                             join universityDepartments in context.UniversityDepartments on universityDepartmentDescriptions.DepartmentId equals universityDepartments.Id

                             where universityDepartmentDescriptions.DeletedDate == null && universityDepartments.DeletedDate == null && universityDepartmentDescriptions.DepartmentId == id

                             select new UniversityDepartmentDescriptionDTO
                             {
                                 Id = universityDepartmentDescriptions.Id,
                                 DepartmentId = universityDepartmentDescriptions.DepartmentId,
                                 DepartmentName = universityDepartments.DepartmentName,
                                 Title = universityDepartmentDescriptions.Title,
                                 Description = universityDepartmentDescriptions.Description,
                                 CreatedDate = universityDepartmentDescriptions.CreatedDate,
                                 UpdatedDate = universityDepartmentDescriptions.UpdatedDate,
                                 DeletedDate = universityDepartmentDescriptions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }


    }
}
