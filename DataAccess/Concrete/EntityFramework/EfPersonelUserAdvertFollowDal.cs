using Core.DataAccess.EntityFramework;
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
    public class EfPersonelUserAdvertFollowDal : EfEntityRepositoryBase<PersonelUserAdvertFollow, KariyerimContext>, IPersonelUserAdvertFollowDal
    {
        public async Task<List<PersonelUserAdvertFollowDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertFollows in context.PersonelUserAdvertFollows
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertFollows.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertFollows.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertFollows.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join personelUserCvs in context.PersonelUserCvs on personelUserAdvertFollows.PersonelUserCvId equals personelUserCvs.Id

                             where users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCvs.DeletedDate == null

                             select new PersonelUserAdvertFollowDTO
                             {
                                 Id = personelUserAdvertFollows.Id,
                                 AdvertId = personelUserAdvertFollows.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertFollows.PersonelUserId,
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
                                 PersonelUserCvId = personelUserAdvertFollows.PersonelUserCvId,
                                 PersonelUserCvName = personelUserCvs.CvName,
                                 CreatedDate = personelUserAdvertFollows.CreatedDate,
                                 UpdatedDate = personelUserAdvertFollows.UpdatedDate,
                                 DeletedDate = personelUserAdvertFollows.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<PersonelUserAdvertFollowDTO>> GetAllByCompanyUserIdDTO(string companyUserId)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertFollows in context.PersonelUserAdvertFollows
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertFollows.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertFollows.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertFollows.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join personelUserCvs in context.PersonelUserCvs on personelUserAdvertFollows.PersonelUserCvId equals personelUserCvs.Id

                             where personelUserAdvertFollows.CompanyUserId == companyUserId && users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCvs.DeletedDate == null

                             select new PersonelUserAdvertFollowDTO
                             {
                                 Id = personelUserAdvertFollows.Id,
                                 AdvertId = personelUserAdvertFollows.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertFollows.PersonelUserId,
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
                                 PersonelUserCvId = personelUserAdvertFollows.PersonelUserCvId,
                                 PersonelUserCvName = personelUserCvs.CvName,
                                 CreatedDate = personelUserAdvertFollows.CreatedDate,
                                 UpdatedDate = personelUserAdvertFollows.UpdatedDate,
                                 DeletedDate = personelUserAdvertFollows.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<PersonelUserAdvertFollowDTO>> GetAllByPersonelUserIdDTO(string personelUserId)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertFollows in context.PersonelUserAdvertFollows
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertFollows.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertFollows.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertFollows.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join personelUserCvs in context.PersonelUserCvs on personelUserAdvertFollows.PersonelUserCvId equals personelUserCvs.Id

                             where personelUserAdvertFollows.PersonelUserId == personelUserId && users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCvs.DeletedDate == null

                             select new PersonelUserAdvertFollowDTO
                             {
                                 Id = personelUserAdvertFollows.Id,
                                 AdvertId = personelUserAdvertFollows.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertFollows.PersonelUserId,
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
                                 PersonelUserCvId = personelUserAdvertFollows.PersonelUserCvId,
                                 PersonelUserCvName = personelUserCvs.CvName,
                                 CreatedDate = personelUserAdvertFollows.CreatedDate,
                                 UpdatedDate = personelUserAdvertFollows.UpdatedDate,
                                 DeletedDate = personelUserAdvertFollows.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<PersonelUserAdvertFollowDTO>> GetAllByAdvertIdDTO(string advertId)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertFollows in context.PersonelUserAdvertFollows
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertFollows.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertFollows.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertFollows.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join personelUserCvs in context.PersonelUserCvs on personelUserAdvertFollows.PersonelUserCvId equals personelUserCvs.Id

                             where personelUserAdvertFollows.AdvertId == advertId && users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCvs.DeletedDate == null

                             select new PersonelUserAdvertFollowDTO
                             {
                                 Id = personelUserAdvertFollows.Id,
                                 AdvertId = personelUserAdvertFollows.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertFollows.PersonelUserId,
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
                                 PersonelUserCvId = personelUserAdvertFollows.PersonelUserCvId,
                                 PersonelUserCvName = personelUserCvs.CvName,
                                 CreatedDate = personelUserAdvertFollows.CreatedDate,
                                 UpdatedDate = personelUserAdvertFollows.UpdatedDate,
                                 DeletedDate = personelUserAdvertFollows.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
