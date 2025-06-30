using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCompanyFollowDal : EfEntityRepositoryBase<CompanyFollow, KariyerimContext>, ICompanyFollowDal
    {
        public List<CompanyFollowDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from advertApplication in context.AdvertApplications

                             join companyUsers in context.CompanyUsers on advertApplication.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on advertApplication.PersonelUserId equals personelUsers.Id

                             select new CompanyFollowDTO
                             {
                                 Id = advertApplication.Id,
                                 PersonelUserId = advertApplication.PersonelUserId,
                                 CreatedDate = advertApplication.CreatedDate,
                                 UpdatedDate = advertApplication.UpdatedDate,
                                 DeletedDate = advertApplication.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<CompanyFollowDTO> GetAllByCompanyIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from advertApplication in context.AdvertApplications
                             join companyUsers in context.CompanyUsers on advertApplication.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on advertApplication.PersonelUserId equals personelUsers.Id

                             where advertApplication.CompanyUserId == id

                             select new CompanyFollowDTO
                             {
                                 Id = advertApplication.Id,
                                 CompanyUserId = advertApplication.CompanyUserId,
                                 PersonelUserId = advertApplication.PersonelUserId,
                                 CreatedDate = advertApplication.CreatedDate,
                                 UpdatedDate = advertApplication.UpdatedDate,
                                 DeletedDate = advertApplication.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<CompanyFollowDTO> GetAllByPersonelIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from advertApplication in context.AdvertApplications
                             join companyUsers in context.CompanyUsers on advertApplication.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on advertApplication.PersonelUserId equals personelUsers.Id

                             where advertApplication.PersonelUserId == id

                             select new CompanyFollowDTO
                             {
                                 Id = advertApplication.Id,
                                 CompanyUserId = advertApplication.CompanyUserId,
                                 PersonelUserId = advertApplication.PersonelUserId,
                                 CreatedDate = advertApplication.CreatedDate,
                                 UpdatedDate = advertApplication.UpdatedDate,
                                 DeletedDate = advertApplication.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }




}
