using Core.DataAccess.EntityFramework;
using Core.Utilities.Business.Constans;
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
    public class EfCompanyUserAdvertJobDescriptionDal : EfEntityRepositoryBase<CompanyUserAdvertJobDescription, KariyerimContext>, ICompanyUserAdvertJobDescriptionDal
    {
        public async Task<List<CompanyUserAdvertJobDescriptionDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserAdvertJobDescription in context.CompanyUserAdvertJobDescriptions
                             join companyUserAdverts in context.CompanyUserAdverts on companyUserAdvertJobDescription.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on companyUserAdvertJobDescription.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUserAdvertJobDescription.UserId equals users.Id

                             where users.Code == UserCodes.CompanyUserCode && companyUserAdvertJobDescription.DeletedDate == null && users.DeletedDate == null && companyUserAdverts.DeletedDate == null 

                             select new CompanyUserAdvertJobDescriptionDTO
                             {
                                 Id = companyUserAdvertJobDescription.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUserAdvertJobDescription.CompanyUserId,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 AdvertId = companyUserAdvertJobDescription.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 Title = companyUserAdvertJobDescription.Title,
                                 Description = companyUserAdvertJobDescription.Description,
                                 CreatedDate = companyUserAdvertJobDescription.CreatedDate,
                                 UpdatedDate = companyUserAdvertJobDescription.UpdatedDate,
                                 DeletedDate = companyUserAdvertJobDescription.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<CompanyUserAdvertJobDescriptionDTO>> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserAdvertJobDescription in context.CompanyUserAdvertJobDescriptions
                             join companyUserAdverts in context.CompanyUserAdverts on companyUserAdvertJobDescription.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on companyUserAdvertJobDescription.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUserAdvertJobDescription.UserId equals users.Id

                             where users.Code == UserCodes.CompanyUserCode && companyUserAdvertJobDescription.DeletedDate != null && users.DeletedDate == null && companyUserAdverts.DeletedDate == null

                             select new CompanyUserAdvertJobDescriptionDTO
                             {
                                 Id = companyUserAdvertJobDescription.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUserAdvertJobDescription.CompanyUserId,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 AdvertId = companyUserAdvertJobDescription.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 Title = companyUserAdvertJobDescription.Title,
                                 Description = companyUserAdvertJobDescription.Description,
                                 CreatedDate = companyUserAdvertJobDescription.CreatedDate,
                                 UpdatedDate = companyUserAdvertJobDescription.UpdatedDate,
                                 DeletedDate = companyUserAdvertJobDescription.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<CompanyUserAdvertJobDescriptionDTO>> GetAllByIdDTO(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserAdvertJobDescriptions in context.CompanyUserAdvertJobDescriptions
                             join companyUserAdverts in context.CompanyUserAdverts on companyUserAdvertJobDescriptions.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on companyUserAdverts.CompanyUserId equals companyUsers.Id

                             where companyUserAdvertJobDescriptions.DeletedDate == null && companyUserAdverts.DeletedDate == null
                              && companyUsers.DeletedDate == null && companyUserAdvertJobDescriptions.AdvertId == id

                             select new CompanyUserAdvertJobDescriptionDTO
                             {
                                 Id = companyUserAdvertJobDescriptions.Id,
                                 Description = companyUserAdvertJobDescriptions.Description,
                                 Title = companyUserAdvertJobDescriptions.Title,
                                 AdvertId = companyUserAdvertJobDescriptions.AdvertId,
                                 AdvertName= companyUserAdverts.AdvertName,
                                 CompanyUserId = companyUserAdverts.CompanyUserId,
                                 CompanyUserName=companyUsers.CompanyUserName,
                                 CreatedDate = companyUserAdvertJobDescriptions.CreatedDate,
                                 UpdatedDate = companyUserAdvertJobDescriptions.UpdatedDate,
                                 DeletedDate = companyUserAdvertJobDescriptions.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
