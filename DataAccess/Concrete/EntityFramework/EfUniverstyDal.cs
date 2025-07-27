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
    public class EfUniverstyDal : EfEntityRepositoryBase<University, KariyerimContext>,IUniversityDal
    {
        public async Task TerminateSubDatas(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var universityDepartmentsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [UniversityDepartments] WHERE [UniversityId] = {id}");
                var universityFacultiesDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [UniversityFaculties] WHERE [UniversityId] = {id}");
                var universityImagesDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [UniversityImages] WHERE [UniversityId] = {id}");
            }
        }
        public List<UniversityDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universities in context.Universities
                             join sectors in context.Sectors on universities.SectorId equals sectors.Id
                             join counts in context.Counts on universities.WorkerCountId equals counts.Id


                             where universities.DeletedDate == null && sectors.DeletedDate == null

                             select new UniversityDTO
                             {
                                 Id = universities.Id,
                                 SectorId = universities.SectorId,
                                 UniversityName = universities.UniversityName,
                                 SectorName = sectors.SectorName,
                                 YearOfEstablishment = universities.YearOfEstablishment,
                                 WorkerCountId = universities.WorkerCountId,
                                 WorkerCountValue=counts.CountValue,
                                 WebAddress = universities.WebAddress,
                                 WebNewsAddress = universities.WebNewsAddress,
                                 YouTubeEmbedAddress = universities.YouTubeEmbedAddress,
                                 Address = universities.Address,
                                 FacebookAddress = universities.FacebookAddress,
                                 InstagramAddress = universities.InstagramAddress,
                                 XAddress = universities.XAddress,
                                 YouTubeAddress = universities.YouTubeAddress,
                                 CreatedDate = universities.CreatedDate,
                                 UpdatedDate = universities.UpdatedDate,
                                 DeletedDate = universities.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<UniversityDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universities in context.Universities
                             join sectors in context.Sectors on universities.SectorId equals sectors.Id
                             join counts in context.Counts on universities.WorkerCountId equals counts.Id


                             where universities.DeletedDate != null && sectors.DeletedDate == null

                             select new UniversityDTO
                             {
                                 Id = universities.Id,
                                 SectorId = universities.SectorId,
                                 UniversityName = universities.UniversityName,
                                 SectorName = sectors.SectorName,
                                 YearOfEstablishment = universities.YearOfEstablishment,
                                 WorkerCountId = universities.WorkerCountId,
                                 WorkerCountValue = counts.CountValue,
                                 WebAddress = universities.WebAddress,
                                 WebNewsAddress = universities.WebNewsAddress,
                                 YouTubeEmbedAddress = universities.YouTubeEmbedAddress,
                                 Address = universities.Address,
                                 FacebookAddress = universities.FacebookAddress,
                                 InstagramAddress = universities.InstagramAddress,
                                 XAddress = universities.XAddress,
                                 YouTubeAddress = universities.YouTubeAddress,
                                 CreatedDate = universities.CreatedDate,
                                 UpdatedDate = universities.UpdatedDate,
                                 DeletedDate = universities.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
