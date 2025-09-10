using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICompanyUserImageDal : IEntityRepository<CompanyUserImage>
    {
        Task<List<CompanyUserImageDTO>> GetAllDTO();
        Task<List<CompanyUserImageDTO>> GetDeletedAllDTO();
        Task UpdateLogoImage(string companyUserId, string imageOwnName, string imagPath, string imageName);
        Task UpdateMainImage(string companyUserId);
        

        Task<List<CompanyUserImage>> GetCompanyUserMainImage(string id);
        Task<List<CompanyUserImage>> GetCompanyUserLogoImage(string id);
    }
}
