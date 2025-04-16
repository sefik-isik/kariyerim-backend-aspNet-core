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
    public class EfCompanyUserFileDal : EfEntityRepositoryBase<CompanyUserFile, KariyerimContext>, ICompanyUserFileDal
    {
        public List<CompanyUserFileDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserFiles in context.CompanyUserFiles
                             join companyUsers in context.CompanyUsers on companyUserFiles.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id

                             select new CompanyUserFileDTO
                             {
                                 Id = companyUserFiles.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
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
