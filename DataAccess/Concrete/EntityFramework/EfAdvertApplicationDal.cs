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
    public class EfAdvertApplicationDal : EfEntityRepositoryBase<AdvertApplication, KariyerimContext>, IAdvertApplicationDal
    {
        public List<AdvertApplicationDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from advertApplication in context.AdvertApplications
                             join companyUserAdverts in context.CompanyUserAdverts on advertApplication.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on advertApplication.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on advertApplication.PersonelUserId equals personelUsers.Id

                             select new AdvertApplicationDTO
                             {
                                 Id = advertApplication.Id,
                                 AdvertId = advertApplication.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = companyUserAdverts.CompanyUserId,
                                 PersonelUserId = advertApplication.PersonelUserId,
                                 CreatedDate = advertApplication.CreatedDate,
                                 UpdatedDate = advertApplication.UpdatedDate,
                                 DeletedDate = advertApplication.DeletedDate,
                             };
                return result.ToList();
            }
        }
        public List<AdvertApplicationDTO> GetAllByCompanyIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from advertApplication in context.AdvertApplications
                             join companyUserAdverts in context.CompanyUserAdverts on advertApplication.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on advertApplication.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on advertApplication.PersonelUserId equals personelUsers.Id

                             where advertApplication.CompanyUserId == id

                             select new AdvertApplicationDTO
                             {
                                 Id = advertApplication.Id,
                                 AdvertId = advertApplication.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = advertApplication.CompanyUserId,
                                 PersonelUserId = advertApplication.PersonelUserId,
                                 CreatedDate = advertApplication.CreatedDate,
                                 UpdatedDate = advertApplication.UpdatedDate,
                                 DeletedDate = advertApplication.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<AdvertApplicationDTO> GetAllByPersonelIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from advertApplication in context.AdvertApplications
                             join companyUserAdverts in context.CompanyUserAdverts on advertApplication.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on advertApplication.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on advertApplication.PersonelUserId equals personelUsers.Id

                             where advertApplication.PersonelUserId == id 

                             select new AdvertApplicationDTO
                             {
                                 Id = advertApplication.Id,
                                 AdvertId = advertApplication.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
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
