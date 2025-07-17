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
    public class EfPersonelUserAdvertFollowDal : EfEntityRepositoryBase<PersonelUserAdvertFollow, KariyerimContext>, IPersonelUserAdvertFollowDal
    {
        public List<PersonelUserAdvertFollowDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertFollows in context.PersonelUserAdvertFollows
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertFollows.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertFollows.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertFollows.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             select new PersonelUserAdvertFollowDTO
                             {
                                 Id = personelUserAdvertFollows.Id,
                                 AdvertId = personelUserAdvertFollows.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = personelUserAdvertFollows.CompanyUserId,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertFollows.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 CreatedDate = personelUserAdvertFollows.CreatedDate,
                                 UpdatedDate = personelUserAdvertFollows.UpdatedDate,
                                 DeletedDate = personelUserAdvertFollows.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<PersonelUserAdvertFollowDTO> GetAllByAdvertIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertFollows in context.PersonelUserAdvertFollows
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertFollows.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertFollows.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertFollows.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where personelUserAdvertFollows.AdvertId == id

                             select new PersonelUserAdvertFollowDTO
                             {
                                 Id = personelUserAdvertFollows.Id,
                                 AdvertId = personelUserAdvertFollows.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = personelUserAdvertFollows.CompanyUserId,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertFollows.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 CreatedDate = personelUserAdvertFollows.CreatedDate,
                                 UpdatedDate = personelUserAdvertFollows.UpdatedDate,
                                 DeletedDate = personelUserAdvertFollows.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<PersonelUserAdvertFollowDTO> GetAllByPersonelIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertFollows in context.PersonelUserAdvertFollows
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertFollows.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertFollows.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertFollows.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where personelUserAdvertFollows.PersonelUserId == id

                             select new PersonelUserAdvertFollowDTO
                             {
                                 Id = personelUserAdvertFollows.Id,
                                 AdvertId = personelUserAdvertFollows.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = personelUserAdvertFollows.CompanyUserId,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertFollows.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 CreatedDate = personelUserAdvertFollows.CreatedDate,
                                 UpdatedDate = personelUserAdvertFollows.UpdatedDate,
                                 DeletedDate = personelUserAdvertFollows.DeletedDate,
                             };
                return result.ToList();
            }
        }


    }
}
