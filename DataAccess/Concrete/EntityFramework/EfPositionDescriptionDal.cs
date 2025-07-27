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
    public class EfPositionDescriptionDal : EfEntityRepositoryBase<PositionDescription, KariyerimContext>, IPositionDescriptionDal
    {
        public List<PositionDescriptionDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from positionDescriptions in context.PositionDescriptions
                             join positions in context.Positions on positionDescriptions.PositionId equals positions.Id

                             where positionDescriptions.DeletedDate == null

                             select new PositionDescriptionDTO
                             {
                                 Id = positionDescriptions.Id,
                                 PositionId = positionDescriptions.PositionId,
                                 PositionName = positions.PositionName,
                                 Title = positionDescriptions.Title,
                                 Description = positionDescriptions.Description,
                                 CreatedDate = positionDescriptions.CreatedDate,
                                 UpdatedDate = positionDescriptions.UpdatedDate,
                                 DeletedDate = positionDescriptions.DeletedDate,
                             };
                return result.ToList();
            }
        }
        public List<PositionDescriptionDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from positionDescriptions in context.PositionDescriptions
                             join positions in context.Positions on positionDescriptions.PositionId equals positions.Id

                             where positionDescriptions.DeletedDate != null

                             select new PositionDescriptionDTO
                             {
                                 Id = positionDescriptions.Id,
                                 PositionId = positionDescriptions.PositionId,
                                 PositionName = positions.PositionName,
                                 Title = positionDescriptions.Title,
                                 Description = positionDescriptions.Description,
                                 CreatedDate = positionDescriptions.CreatedDate,
                                 UpdatedDate = positionDescriptions.UpdatedDate,
                                 DeletedDate = positionDescriptions.DeletedDate,
                             };
                return result.ToList();
            }
        }
        public List<PositionDescriptionDTO> GetAllByPositionIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from positionDescriptions in context.PositionDescriptions
                             join positions in context.Positions on positionDescriptions.PositionId equals positions.Id

                             where positionDescriptions.DeletedDate == null && positionDescriptions.PositionId == id

                             select new PositionDescriptionDTO
                             {
                                 Id = positionDescriptions.Id,
                                 PositionId = positionDescriptions.PositionId,
                                 PositionName = positions.PositionName,
                                 Title = positionDescriptions.Title,
                                 Description = positionDescriptions.Description,
                                 CreatedDate = positionDescriptions.CreatedDate,
                                 UpdatedDate = positionDescriptions.UpdatedDate,
                                 DeletedDate = positionDescriptions.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
