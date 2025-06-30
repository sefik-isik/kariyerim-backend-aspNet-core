using Core.DataAccess.EntityFramework;
using Core.Utilities.Business.Constans;
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
    public class EfCompanyUserAdvertJobDescriptionDal : EfEntityRepositoryBase<CompanyUserAdvertJobDescription, KariyerimContext>, ICompanyUserAdvertJobDescriptionDal
    {
        public List<CompanyUserAdvertJobDescriptionDTO> GetAllDTO()
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
                return result.ToList();
            }
        }

        public List<CompanyUserAdvertJobDescriptionDTO> GetDeletedAllDTO()
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
                return result.ToList();
            }
        }
    }
}
