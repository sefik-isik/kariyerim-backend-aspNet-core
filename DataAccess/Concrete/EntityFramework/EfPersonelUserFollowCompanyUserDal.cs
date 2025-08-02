using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfPersonelUserFollowCompanyUserDal : EfEntityRepositoryBase<PersonelUserFollowCompanyUser, KariyerimContext>, IPersonelUserFollowCompanyUserDal
    {
        public async Task<List<PersonelUserFollowCompanyUserDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserFollowCompanyUsers in context.PersonelUserFollowCompanyUsers
                             join companyUsers in context.CompanyUsers on personelUserFollowCompanyUsers.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserFollowCompanyUsers.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null

                             select new PersonelUserFollowCompanyUserDTO
                             {
                                 Id = personelUserFollowCompanyUsers.Id,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserFollowCompanyUsers.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 CreatedDate = personelUserFollowCompanyUsers.CreatedDate,
                                 UpdatedDate = personelUserFollowCompanyUsers.UpdatedDate,
                                 DeletedDate = personelUserFollowCompanyUsers.DeletedDate,
                             };

                return await result.ToListAsync();
            }
        }

        public async Task<List<PersonelUserFollowCompanyUserDTO>> GetAllByCompanyIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserFollowCompanyUsers in context.PersonelUserFollowCompanyUsers
                             join companyUsers in context.CompanyUsers on personelUserFollowCompanyUsers.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserFollowCompanyUsers.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where companyUsers.UserId == id && users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null

                             select new PersonelUserFollowCompanyUserDTO
                             {
                                 Id = personelUserFollowCompanyUsers.Id,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserFollowCompanyUsers.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 CreatedDate = personelUserFollowCompanyUsers.CreatedDate,
                                 UpdatedDate = personelUserFollowCompanyUsers.UpdatedDate,
                                 DeletedDate = personelUserFollowCompanyUsers.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<PersonelUserFollowCompanyUserDTO>> GetAllByPersonelIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserFollowCompanyUsers in context.PersonelUserFollowCompanyUsers
                             join companyUsers in context.CompanyUsers on personelUserFollowCompanyUsers.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserFollowCompanyUsers.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where personelUsers.UserId == id && users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null

                             select new PersonelUserFollowCompanyUserDTO
                             {
                                 Id = personelUserFollowCompanyUsers.Id,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserFollowCompanyUsers.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 CreatedDate = personelUserFollowCompanyUsers.CreatedDate,
                                 UpdatedDate = personelUserFollowCompanyUsers.UpdatedDate,
                                 DeletedDate = personelUserFollowCompanyUsers.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
    }




}
