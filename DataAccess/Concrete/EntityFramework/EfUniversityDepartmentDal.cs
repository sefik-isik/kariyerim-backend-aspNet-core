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
    public class EfUniversityDepartmentDal : EfEntityRepositoryBase<UniversityDepartment, KariyerimContext>, IUniversityDepartmentDal
    {
        public async Task TerminateSubDatas(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var universityDepartmentDescriptionsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [UniversityDepartmentDescriptions] WHERE [UniversityDepartmentId] = {id}");
            }
        }
    }
}
