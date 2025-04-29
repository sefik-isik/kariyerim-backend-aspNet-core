using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfCompanyUserDepartmentDal : EfEntityRepositoryBase<CompanyUserDepartment, KariyerimContext>, ICompanyUserDepartmentDal
    {
        public List<CompanyUserDepartmentDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from companyUserDepartments in context.CompanyUserDepartments
                             join companyUsers in context.CompanyUsers on companyUserDepartments.CompanyUserId equals companyUsers.Id
                             join users in context.Users on companyUsers.UserId equals users.Id

                             select new CompanyUserDepartmentDTO
                             {
                                 Id = companyUserDepartments.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 DepartmentName = companyUserDepartments.DepartmentName,
                                 CreatedDate = companyUserDepartments.CreatedDate,
                                 UpdatedDate = companyUserDepartments.UpdatedDate,
                                 DeletedDate = companyUserDepartments.DeletedDate,
                             };
                return result.ToList();
            }
        }
    
        
    }
}
