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
    public class EfCompanyUserFileDal : EfEntityRepositoryBase<CompanyUserFile, KariyerimContext>, ICompanyUserFileDal
    {
        public List<CompanyUserFileDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserFiles in context.CompanyUserFiles
                             join companyUsers in context.CompanyUsers on companyUserFiles.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id

                             where users.Code == UserCodes.CompanyUserCode &&
                             companyUserFiles.DeletedDate == null && users.DeletedDate == null && companyUsers.DeletedDate == null

                             select new CompanyUserFileDTO
                             {
                                 Id = companyUserFiles.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 FileName = companyUserFiles.FileName,
                                 FilePath = companyUserFiles.FilePath,
                                 CreatedDate = companyUserFiles.CreatedDate,
                                 UpdatedDate = companyUserFiles.UpdatedDate,
                                 DeletedDate = companyUserFiles.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<CompanyUserFileDTO> GetDeletedAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserFiles in context.CompanyUserFiles
                             join companyUsers in context.CompanyUsers on companyUserFiles.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id

                             where users.Code == UserCodes.CompanyUserCode &&
                             companyUserFiles.DeletedDate != null && users.DeletedDate == null && companyUsers.DeletedDate == null

                             select new CompanyUserFileDTO
                             {
                                 Id = companyUserFiles.Id,
                                 UserId = users.Id,
                                 Email = users.Email,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 FileName = companyUserFiles.FileName,
                                 FilePath = companyUserFiles.FilePath,
                                 CreatedDate = companyUserFiles.CreatedDate,
                                 UpdatedDate = companyUserFiles.UpdatedDate,
                                 DeletedDate = companyUserFiles.DeletedDate,
                             };
                return result.ToList();
            }
        }

    }
}
