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
    public class EfPersonelUserAdvertApplicationDal : EfEntityRepositoryBase<PersonelUserAdvertApplication, KariyerimContext>, IPersonelUserAdvertApplicationDal
    {
        public List<PersonelUserAdvertApplicationDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertApplications in context.PersonelUserAdvertApplications
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertApplications.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertApplications.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertApplications.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             select new PersonelUserAdvertApplicationDTO
                             {
                                 Id = personelUserAdvertApplications.Id,
                                 AdvertId = personelUserAdvertApplications.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = personelUserAdvertApplications.CompanyUserId,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertApplications.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 CreatedDate = personelUserAdvertApplications.CreatedDate,
                                 UpdatedDate = personelUserAdvertApplications.UpdatedDate,
                                 DeletedDate = personelUserAdvertApplications.DeletedDate,
                             };
                return result.ToList();
            }
        }
        public List<PersonelUserAdvertApplicationDTO> GetAllByAdvertIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertApplications in context.PersonelUserAdvertApplications
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertApplications.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertApplications.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertApplications.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where personelUserAdvertApplications.AdvertId == id

                             select new PersonelUserAdvertApplicationDTO
                             {
                                 Id = personelUserAdvertApplications.Id,
                                 AdvertId = personelUserAdvertApplications.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = personelUserAdvertApplications.CompanyUserId,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertApplications.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 CreatedDate = personelUserAdvertApplications.CreatedDate,
                                 UpdatedDate = personelUserAdvertApplications.UpdatedDate,
                                 DeletedDate = personelUserAdvertApplications.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<PersonelUserAdvertApplicationDTO> GetAllByPersonelIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertApplications in context.PersonelUserAdvertApplications
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertApplications.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertApplications.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertApplications.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where personelUserAdvertApplications.PersonelUserId == id 

                             select new PersonelUserAdvertApplicationDTO
                             {
                                 Id = personelUserAdvertApplications.Id,
                                 AdvertId = personelUserAdvertApplications.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = personelUserAdvertApplications.CompanyUserId,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertApplications.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 CreatedDate = personelUserAdvertApplications.CreatedDate,
                                 UpdatedDate = personelUserAdvertApplications.UpdatedDate,
                                 DeletedDate = personelUserAdvertApplications.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
