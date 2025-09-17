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
                             join personelUserCvs in context.PersonelUserCvs on personelUserFollowCompanyUsers.PersonelUserCvId equals personelUserCvs.Id

                             where users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCvs.DeletedDate == null

                             select new PersonelUserFollowCompanyUserDTO
                             {
                                 Id = personelUserFollowCompanyUsers.Id,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserFollowCompanyUsers.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 PersonelUserFirstName = users.FirstName,
                                 PersonelUserLastName = users.LastName,
                                 PersonelUserPhoneNumber = users.PhoneNumber,
                                 PersonelUserTitle = personelUsers.Title,
                                 PersonelUserGender = personelUsers.Gender,
                                 PersonelUserDateOfBirth = personelUsers.DateOfBirth,
                                 PersonelUserMilitaryStatus = personelUsers.MilitaryStatus,
                                 PersonelUserNationalStatus = personelUsers.NationalStatus,
                                 PersonelUserRetirementStatus = personelUsers.RetirementStatus,
                                 CompanyUserImagePath = companyUsers.ImagePath,
                                 CompanyUserImageName = companyUsers.ImageName,
                                 CompanyUserImageOwnName = companyUsers.ImageOwnName,
                                 PersonelUserImagePath = personelUsers.ImagePath,
                                 PersonelUserImageName = personelUsers.ImageName,
                                 PersonelUserImageOwnName = personelUsers.ImageOwnName,
                                 PersonelUserCvId = personelUserFollowCompanyUsers.PersonelUserCvId,
                                 PersonelUserCvName = personelUserCvs.CvName,
                                 CreatedDate = personelUserFollowCompanyUsers.CreatedDate,
                                 UpdatedDate = personelUserFollowCompanyUsers.UpdatedDate,
                                 DeletedDate = personelUserFollowCompanyUsers.DeletedDate,
                             };

                return await result.ToListAsync();
            }
        }

        public async Task<List<PersonelUserFollowCompanyUserDTO>> GetAllByCompanyUserIdDTO(string companyUserId)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserFollowCompanyUsers in context.PersonelUserFollowCompanyUsers
                             join companyUsers in context.CompanyUsers on personelUserFollowCompanyUsers.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserFollowCompanyUsers.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join personelUserCvs in context.PersonelUserCvs on personelUserFollowCompanyUsers.PersonelUserCvId equals personelUserCvs.Id

                             where personelUserFollowCompanyUsers.CompanyUserId == companyUserId && users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCvs.DeletedDate == null

                             select new PersonelUserFollowCompanyUserDTO
                             {
                                 Id = personelUserFollowCompanyUsers.Id,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserFollowCompanyUsers.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 PersonelUserFirstName = users.FirstName,
                                 PersonelUserLastName = users.LastName,
                                 PersonelUserPhoneNumber = users.PhoneNumber,
                                 PersonelUserTitle = personelUsers.Title,
                                 PersonelUserGender = personelUsers.Gender,
                                 PersonelUserDateOfBirth = personelUsers.DateOfBirth,
                                 PersonelUserMilitaryStatus = personelUsers.MilitaryStatus,
                                 PersonelUserNationalStatus = personelUsers.NationalStatus,
                                 PersonelUserRetirementStatus = personelUsers.RetirementStatus,
                                 CompanyUserImagePath = companyUsers.ImagePath,
                                 CompanyUserImageName = companyUsers.ImageName,
                                 CompanyUserImageOwnName = companyUsers.ImageOwnName,
                                 PersonelUserImagePath = personelUsers.ImagePath,
                                 PersonelUserImageName = personelUsers.ImageName,
                                 PersonelUserImageOwnName = personelUsers.ImageOwnName,
                                 PersonelUserCvId = personelUserFollowCompanyUsers.PersonelUserCvId,
                                 PersonelUserCvName = personelUserCvs.CvName,
                                 CreatedDate = personelUserFollowCompanyUsers.CreatedDate,
                                 UpdatedDate = personelUserFollowCompanyUsers.UpdatedDate,
                                 DeletedDate = personelUserFollowCompanyUsers.DeletedDate,
                             };

                return await result.ToListAsync();
            }
        }

        public async Task<List<PersonelUserFollowCompanyUserDTO>> GetAllByPersonelUserIdDTO(string personelUserId)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserFollowCompanyUsers in context.PersonelUserFollowCompanyUsers
                             join companyUsers in context.CompanyUsers on personelUserFollowCompanyUsers.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserFollowCompanyUsers.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join personelUserCvs in context.PersonelUserCvs on personelUserFollowCompanyUsers.PersonelUserCvId equals personelUserCvs.Id

                             where personelUserFollowCompanyUsers.PersonelUserId == personelUserId && users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCvs.DeletedDate == null

                             select new PersonelUserFollowCompanyUserDTO
                             {
                                 Id = personelUserFollowCompanyUsers.Id,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserFollowCompanyUsers.PersonelUserId,
                                 PersonelUserMail = users.Email,
                                 PersonelUserFirstName = users.FirstName,
                                 PersonelUserLastName = users.LastName,
                                 PersonelUserPhoneNumber = users.PhoneNumber,
                                 PersonelUserTitle = personelUsers.Title,
                                 PersonelUserGender = personelUsers.Gender,
                                 PersonelUserDateOfBirth = personelUsers.DateOfBirth,
                                 PersonelUserMilitaryStatus = personelUsers.MilitaryStatus,
                                 PersonelUserNationalStatus = personelUsers.NationalStatus,
                                 PersonelUserRetirementStatus = personelUsers.RetirementStatus,
                                 CompanyUserImagePath = companyUsers.ImagePath,
                                 CompanyUserImageName = companyUsers.ImageName,
                                 CompanyUserImageOwnName = companyUsers.ImageOwnName,
                                 PersonelUserImagePath = personelUsers.ImagePath,
                                 PersonelUserImageName = personelUsers.ImageName,
                                 PersonelUserImageOwnName = personelUsers.ImageOwnName,
                                 PersonelUserCvId = personelUserFollowCompanyUsers.PersonelUserCvId,
                                 PersonelUserCvName = personelUserCvs.CvName,
                                 CreatedDate = personelUserFollowCompanyUsers.CreatedDate,
                                 UpdatedDate = personelUserFollowCompanyUsers.UpdatedDate,
                                 DeletedDate = personelUserFollowCompanyUsers.DeletedDate,
                             };

                return await result.ToListAsync();
            }
        }
    }
}
