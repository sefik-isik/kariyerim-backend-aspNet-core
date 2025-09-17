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
    public class EfPersonelUserAdvertApplicationDal : EfEntityRepositoryBase<PersonelUserAdvertApplication, KariyerimContext>, IPersonelUserAdvertApplicationDal
    {
        public async Task<List<PersonelUserAdvertApplicationDTO>> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertApplications in context.PersonelUserAdvertApplications
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertApplications.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertApplications.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertApplications.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join personelUserCvs in context.PersonelUserCvs on personelUserAdvertApplications.PersonelUserCvId equals personelUserCvs.Id

                             where users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCvs.DeletedDate == null

                             select new PersonelUserAdvertApplicationDTO
                             {
                                 Id = personelUserAdvertApplications.Id,
                                 AdvertId = personelUserAdvertApplications.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertApplications.PersonelUserId,
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
                                 PersonelUserCvId = personelUserAdvertApplications.PersonelUserCvId,
                                 PersonelUserCvName = personelUserCvs.CvName,
                                 CreatedDate = personelUserAdvertApplications.CreatedDate,
                                 UpdatedDate = personelUserAdvertApplications.UpdatedDate,
                                 DeletedDate = personelUserAdvertApplications.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<PersonelUserAdvertApplicationDTO>> GetAllByCompanyUserIdDTO(string companyUserId)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertApplications in context.PersonelUserAdvertApplications
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertApplications.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertApplications.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertApplications.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join personelUserCvs in context.PersonelUserCvs on personelUserAdvertApplications.PersonelUserCvId equals personelUserCvs.Id

                             where personelUserAdvertApplications.CompanyUserId == companyUserId && users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCvs.DeletedDate == null

                             select new PersonelUserAdvertApplicationDTO
                             {
                                 Id = personelUserAdvertApplications.Id,
                                 AdvertId = personelUserAdvertApplications.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertApplications.PersonelUserId,
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
                                 PersonelUserCvId = personelUserAdvertApplications.PersonelUserCvId,
                                 PersonelUserCvName = personelUserCvs.CvName,
                                 CreatedDate = personelUserAdvertApplications.CreatedDate,
                                 UpdatedDate = personelUserAdvertApplications.UpdatedDate,
                                 DeletedDate = personelUserAdvertApplications.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<PersonelUserAdvertApplicationDTO>> GetAllByPersonelUserIdDTO(string personelUserId)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertApplications in context.PersonelUserAdvertApplications
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertApplications.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertApplications.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertApplications.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join personelUserCvs in context.PersonelUserCvs on personelUserAdvertApplications.PersonelUserCvId equals personelUserCvs.Id

                             where personelUserAdvertApplications.PersonelUserId == personelUserId && users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCvs.DeletedDate == null

                             select new PersonelUserAdvertApplicationDTO
                             {
                                 Id = personelUserAdvertApplications.Id,
                                 AdvertId = personelUserAdvertApplications.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertApplications.PersonelUserId,
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
                                 PersonelUserCvId = personelUserAdvertApplications.PersonelUserCvId,
                                 PersonelUserCvName = personelUserCvs.CvName,
                                 CreatedDate = personelUserAdvertApplications.CreatedDate,
                                 UpdatedDate = personelUserAdvertApplications.UpdatedDate,
                                 DeletedDate = personelUserAdvertApplications.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<PersonelUserAdvertApplicationDTO>> GetAllByAdvertIdDTO(string advertId)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserAdvertApplications in context.PersonelUserAdvertApplications
                             join companyUserAdverts in context.CompanyUserAdverts on personelUserAdvertApplications.AdvertId equals companyUserAdverts.Id
                             join companyUsers in context.CompanyUsers on personelUserAdvertApplications.CompanyUserId equals companyUsers.Id
                             join personelUsers in context.PersonelUsers on personelUserAdvertApplications.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id
                             join personelUserCvs in context.PersonelUserCvs on personelUserAdvertApplications.PersonelUserCvId equals personelUserCvs.Id

                             where personelUserAdvertApplications.AdvertId == advertId && users.DeletedDate == null && companyUsers.DeletedDate == null && personelUsers.DeletedDate == null && personelUserCvs.DeletedDate == null

                             select new PersonelUserAdvertApplicationDTO
                             {
                                 Id = personelUserAdvertApplications.Id,
                                 AdvertId = personelUserAdvertApplications.AdvertId,
                                 AdvertName = companyUserAdverts.AdvertName,
                                 CompanyUserId = companyUsers.Id,
                                 CompanyUserName = companyUsers.CompanyUserName,
                                 PersonelUserId = personelUserAdvertApplications.PersonelUserId,
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
                                 PersonelUserCvId = personelUserAdvertApplications.PersonelUserCvId,
                                 PersonelUserCvName = personelUserCvs.CvName,
                                 CreatedDate = personelUserAdvertApplications.CreatedDate,
                                 UpdatedDate = personelUserAdvertApplications.UpdatedDate,
                                 DeletedDate = personelUserAdvertApplications.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
