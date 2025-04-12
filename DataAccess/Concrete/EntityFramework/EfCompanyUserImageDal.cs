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
    public class EfCompanyUserImageDal : EfEntityRepositoryBase<CompanyUserImage, KariyerimContext>, ICompanyUserImageDal
    {
        public List<CompanyUserImageDTO> GetCompanyUserImageDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserImages in context.CompanyUserImages
                             join companyUsers in context.CompanyUsers on companyUserImages.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id

                             where companyUserImages.DeletedDate == null
                             select new CompanyUserImageDTO
                             {
                                 Id = companyUserImages.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
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
        public List<CompanyUserImageDTO> GetCompanyUserImageDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserImages in context.CompanyUserImages
                             join companyUsers in context.CompanyUsers on companyUserImages.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id

                             where companyUserImages.DeletedDate != null
                             select new CompanyUserImageDTO
                             {
                                 Id = companyUserImages.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
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
