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
    public class EfCompanyUserImageDal : EfEntityRepositoryBase<CompanyUserImage, KariyerimContext>, ICompanyUserImageDal
    {
        public List<CompanyUserImageDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserImages in context.CompanyUserImages
                             join companyUsers in context.CompanyUsers on companyUserImages.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id

                             where users.Code == UserCodes.CompanyUserCode &&
                             companyUserImages.DeletedDate == null && users.DeletedDate == null && companyUsers.DeletedDate == null

                             select new CompanyUserImageDTO
                             {
                                 Id = companyUserImages.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 ImageName = companyUserImages.ImageName,
                                 ImagePath = companyUserImages.ImagePath,
                                 CreatedDate = companyUserImages.CreatedDate,
                                 UpdatedDate = companyUserImages.UpdatedDate,
                                 DeletedDate = companyUserImages.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<CompanyUserImageDTO> GetAllDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserImages in context.CompanyUserImages
                             join companyUsers in context.CompanyUsers on companyUserImages.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id

                             where users.Code == UserCodes.CompanyUserCode &&
                             companyUserImages.DeletedDate != null && users.DeletedDate == null && companyUsers.DeletedDate == null

                             select new CompanyUserImageDTO
                             {
                                 Id = companyUserImages.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 ImageName = companyUserImages.ImageName,
                                 ImagePath = companyUserImages.ImagePath,
                                 CreatedDate = companyUserImages.CreatedDate,
                                 UpdatedDate = companyUserImages.UpdatedDate,
                                 DeletedDate = companyUserImages.DeletedDate,
                             };
                return result.ToList();
            }
        }

    }
}
