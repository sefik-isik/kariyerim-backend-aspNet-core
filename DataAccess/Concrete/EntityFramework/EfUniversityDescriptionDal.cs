using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfUniversityDescriptionDal : EfEntityRepositoryBase<UniversityDescription, KariyerimContext>, IUniversityDescriptionDal
    {
        public async Task<List<UniversityDescriptionDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityDescriptions in context.UniversityDescriptions
                             join universities in context.Universities on universityDescriptions.UniversityId equals universities.Id

                             where universityDescriptions.DeletedDate == null && universities.DeletedDate == null

                             select new UniversityDescriptionDTO
                             {
                                 Id = universityDescriptions.Id,
                                 UniversityId = universities.Id,
                                 UniversityName = universities.UniversityName,
                                 Title = universityDescriptions.Title,
                                 Description = universityDescriptions.Description,
                                 CreatedDate = universityDescriptions.CreatedDate,
                                 UpdatedDate = universityDescriptions.UpdatedDate,
                                 DeletedDate = universityDescriptions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<UniversityDescriptionDTO>> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityDescriptions in context.UniversityDescriptions
                             join universities in context.Universities on universityDescriptions.UniversityId equals universities.Id

                             where universityDescriptions.DeletedDate != null && universities.DeletedDate == null

                             select new UniversityDescriptionDTO
                             {
                                 Id = universityDescriptions.Id,
                                 UniversityId = universities.Id,
                                 UniversityName = universities.UniversityName,
                                 Title = universityDescriptions.Title,
                                 Description = universityDescriptions.Description,
                                 CreatedDate = universityDescriptions.CreatedDate,
                                 UpdatedDate = universityDescriptions.UpdatedDate,
                                 DeletedDate = universityDescriptions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<UniversityDescriptionDTO>> GetAllByUniversityIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universityDescriptions in context.UniversityDescriptions
                             join universities in context.Universities on universityDescriptions.UniversityId equals universities.Id

                             where universityDescriptions.DeletedDate == null && universities.DeletedDate == null && universityDescriptions.UniversityId == id

                             select new UniversityDescriptionDTO
                             {
                                 Id = universityDescriptions.Id,
                                 UniversityId = universities.Id,
                                 UniversityName = universities.UniversityName,
                                 Title = universityDescriptions.Title,
                                 Description = universityDescriptions.Description,
                                 CreatedDate = universityDescriptions.CreatedDate,
                                 UpdatedDate = universityDescriptions.UpdatedDate,
                                 DeletedDate = universityDescriptions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
