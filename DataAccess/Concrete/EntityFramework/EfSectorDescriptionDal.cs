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
    public class EfSectorDescriptionDal : EfEntityRepositoryBase<SectorDescription, KariyerimContext>, ISectorDescriptionDal
    {
        public async Task<List<SectorDescriptionDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from sectorDescriptions in context.SectorDescriptions
                             join sectors in context.Sectors on sectorDescriptions.SectorId equals sectors.Id

                             where sectorDescriptions.DeletedDate == null

                             select new SectorDescriptionDTO
                             {
                                 Id = sectorDescriptions.Id,
                                 SectorId = sectorDescriptions.SectorId,
                                 SectorName = sectors.SectorName,
                                 Title = sectorDescriptions.Title,
                                 Description = sectorDescriptions.Description,
                                 CreatedDate = sectorDescriptions.CreatedDate,
                                 UpdatedDate = sectorDescriptions.UpdatedDate,
                                 DeletedDate = sectorDescriptions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<SectorDescriptionDTO>> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from sectorDescriptions in context.SectorDescriptions
                             join sectors in context.Sectors on sectorDescriptions.SectorId equals sectors.Id

                             where sectorDescriptions.DeletedDate != null

                             select new SectorDescriptionDTO
                             {
                                 Id = sectorDescriptions.Id,
                                 SectorId = sectorDescriptions.SectorId,
                                 SectorName = sectors.SectorName,
                                 Title = sectorDescriptions.Title,
                                 Description = sectorDescriptions.Description,
                                 CreatedDate = sectorDescriptions.CreatedDate,
                                 UpdatedDate = sectorDescriptions.UpdatedDate,
                                 DeletedDate = sectorDescriptions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<SectorDescriptionDTO>> GetAllBySectorIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from sectorDescriptions in context.SectorDescriptions
                             join sectors in context.Sectors on sectorDescriptions.SectorId equals sectors.Id

                             where sectorDescriptions.DeletedDate == null && sectorDescriptions.SectorId == id

                             select new SectorDescriptionDTO
                             {
                                 Id = sectorDescriptions.Id,
                                 SectorId = sectorDescriptions.SectorId,
                                 SectorName = sectors.SectorName,
                                 Title = sectorDescriptions.Title,
                                 Description = sectorDescriptions.Description,
                                 CreatedDate = sectorDescriptions.CreatedDate,
                                 UpdatedDate = sectorDescriptions.UpdatedDate,
                                 DeletedDate = sectorDescriptions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
