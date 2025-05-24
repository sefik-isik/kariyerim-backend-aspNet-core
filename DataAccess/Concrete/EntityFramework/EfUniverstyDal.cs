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
    public class EfUniverstyDal : EfEntityRepositoryBase<University, KariyerimContext>,IUniversityDal
    {
        public List<UniversityDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from universities in context.Universities
                             join sectors in context.Sectors on universities.SectorId equals sectors.Id


                             where universities.DeletedDate == null && sectors.DeletedDate == null

                             select new UniversityDTO
                             {
                                 Id = universities.Id,
                                 SectorId = universities.SectorId,
                                 UniversityName = universities.UniversityName,
                                 SectorName = sectors.SectorName,
                                 YearOfEstablishment = universities.YearOfEstablishment,
                                 WorkerCount = universities.WorkerCount,
                                 WebAddress = universities.WebAddress,
                                 WebNewsAddress = universities.WebNewsAddress,
                                 YouTubeEmbedAddress = universities.YouTubeEmbedAddress,
                                 Address = universities.Address,
                                 FacebookAddress = universities.FacebookAddress,
                                 InstagramAddress = universities.InstagramAddress,
                                 XAddress = universities.XAddress,
                                 YouTubeAddress = universities.YouTubeAddress,
                                 Description = universities.Description,
                                 SubDescription = universities.SubDescription,
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


                             where universities.DeletedDate != null && sectors.DeletedDate == null

                             select new UniversityDTO
                             {
                                 Id = universities.Id,
                                 SectorId = universities.SectorId,
                                 UniversityName = universities.UniversityName,
                                 SectorName = sectors.SectorName,
                                 YearOfEstablishment = universities.YearOfEstablishment,
                                 WorkerCount = universities.WorkerCount,
                                 WebAddress = universities.WebAddress,
                                 WebNewsAddress = universities.WebNewsAddress,
                                 YouTubeEmbedAddress = universities.YouTubeEmbedAddress,
                                 Address = universities.Address,
                                 FacebookAddress = universities.FacebookAddress,
                                 InstagramAddress = universities.InstagramAddress,
                                 XAddress = universities.XAddress,
                                 YouTubeAddress = universities.YouTubeAddress,
                                 Description = universities.Description,
                                 SubDescription = universities.SubDescription,
                                 CreatedDate = universities.CreatedDate,
                                 UpdatedDate = universities.UpdatedDate,
                                 DeletedDate = universities.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
