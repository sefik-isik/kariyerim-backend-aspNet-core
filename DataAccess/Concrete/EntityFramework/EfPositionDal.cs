using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPositionDal : EfEntityRepositoryBase<Position, KariyerimContext>, IPositionDal
    {
        public async Task TerminateSubDatas(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var positionDescriptionsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PositionDescriptions] WHERE [PositionId] = {id}");
            }
        }
    }
}
