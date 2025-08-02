using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Business.Constans;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    
    public class EfUserDal : EfEntityRepositoryBase<User, KariyerimContext>, IUserDal
    {
        ICompanyUserDal _companyUserDal;
        IPersonelUserDal _personelUserDal;

        public EfUserDal(ICompanyUserDal companyUserDal, IPersonelUserDal personelUserDal)
        {
            _companyUserDal = companyUserDal;
            _personelUserDal = personelUserDal;
        }

        public async Task TerminateSubDatas(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                List<CompanyUser> companyUserList = await GetAllCompanyUserByUserId(id);
                if (companyUserList != null && companyUserList.Count > 0)
                {
                    foreach (var companyUser in companyUserList)
                    {
                        _companyUserDal.TerminateSubDatas(companyUser.Id);
                    }
                }

                List<PersonelUser> personelUserList = await GetAllPersonelUserByUserId(id);
                if (personelUserList != null && personelUserList.Count > 0)
                {
                    foreach (var personelUser in personelUserList)
                    {
                        _personelUserDal.TerminateSubDatas(personelUser.Id);
                    }
                }

                var companyUsersDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [CompanyUsers] WHERE [UserId] = {id}");
                var personelUsersDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [PersonelUsers] WHERE [UserId] = {id}");
                var userOperationClaimsDeleted = await context.Database.ExecuteSqlAsync($"DELETE FROM [UserOperationClaims] WHERE [UserId] = {id}");
            }
        }

        private async Task<List<CompanyUser>> GetAllCompanyUserByUserId(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var companyUserList = from companyUsers in context.CompanyUsers
                              join users in context.Users on companyUsers.UserId equals users.Id
                              where companyUsers.UserId == id
                              select new CompanyUser
                              {
                                  Id = companyUsers.Id,
                              };
                return await companyUserList.ToListAsync();
            }
        }

        private async Task<List<PersonelUser>> GetAllPersonelUserByUserId(string id)
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var personelUserList = from personelUsers in context.PersonelUsers
                                      join users in context.Users on personelUsers.UserId equals users.Id
                                      where personelUsers.UserId == id
                                      select new PersonelUser
                                      {
                                          Id = personelUsers.Id,
                                      };
                return await personelUserList.ToListAsync();
            }
        }

        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            using (var context = new KariyerimContext())
            {
                var result = from operationClaims in context.OperationClaims
                             join userOperationClaims in context.UserOperationClaims on operationClaims.Id equals userOperationClaims.OperationClaimId
                             join users in context.Users on userOperationClaims.UserId equals users.Id


                             where userOperationClaims.UserId == user.Id 

                             select new OperationClaim { Id = operationClaims.Id, Name = operationClaims.Name };
                return await result.ToListAsync();

            }
        }

        public async Task<List<UserDTO>> GetAllDTO()
        {
            using (var context = new KariyerimContext())
            {
                var result = from users in context.Users

                             where users.DeletedDate == null

                             select new UserDTO { 
                                 Id = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Email = users.Email,
                                 Code = users.Code,
                                 Status = users.Status,
                                 CreatedDate = users.CreatedDate,
                                 UpdatedDate= users.UpdatedDate,
                                 DeletedDate= users.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<UserDTO>> GetAllCompanyUserDTO()
        {
            using (var context = new KariyerimContext())
            {
                var result = from users in context.Users

                             where users.DeletedDate == null && users.Code == UserCodes.CompanyUserCode

                             select new UserDTO
                             {
                                 Id = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Email = users.Email,
                                 Code = users.Code,
                                 Status = users.Status,
                                 CreatedDate = users.CreatedDate,
                                 UpdatedDate = users.UpdatedDate,
                                 DeletedDate = users.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<UserDTO>> GetAllPersonelUserDTO()
        {
            using (var context = new KariyerimContext())
            {
                var result = from users in context.Users

                             where users.DeletedDate == null && users.Code == UserCodes.PersonelUserCode

                             select new UserDTO
                             {
                                 Id = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Email = users.Email,
                                 Code = users.Code,
                                 Status = users.Status,
                                 CreatedDate = users.CreatedDate,
                                 UpdatedDate = users.UpdatedDate,
                                 DeletedDate = users.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<UserDTO>> GetDeletedAllDTO()
        {
            using (var context = new KariyerimContext())
            {
                var result = from users in context.Users

                             where users.DeletedDate != null

                             select new UserDTO { 
                                 Id = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Email = users.Email,
                                 Code = users.Code,
                                 Status = users.Status,
                                 CreatedDate = users.CreatedDate,
                                 UpdatedDate= users.UpdatedDate,
                                 DeletedDate= users.DeletedDate,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<UserDTO> GetByIdForAdminDTO(string id)
        {
            using (var context = new KariyerimContext())
            {
                var result = from users in context.Users
                             where users.Id == id
                             select new UserDTO
                             {
                                 Id = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Email = users.Email,
                                 Code = users.Code,
                                 Status = users.Status,
                                 CreatedDate = users.CreatedDate,
                                 UpdatedDate = users.UpdatedDate,
                                 DeletedDate = users.DeletedDate,
                             };
                return await result.FirstOrDefaultAsync();
            }
        }

        public async Task<UserDTO> GetByIdDTO(string userId, string id)
        {
            using (var context = new KariyerimContext())
            {
                var result = from users in context.Users
                             where users.Id == userId && users.Id == id
                             select new UserDTO
                             {
                                 Id = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 PhoneNumber = users.PhoneNumber,
                                 Email = users.Email,
                                 Code = users.Code,
                                 Status = users.Status,
                                 CreatedDate = users.CreatedDate,
                                 UpdatedDate = users.UpdatedDate,
                                 DeletedDate = users.DeletedDate,
                             };
                return await result.FirstOrDefaultAsync();
            }
        }
        public async Task<List<UserCodeDTO>> GetCode(string userId)
        {
            using (var context = new KariyerimContext())
            {
                var result = from users in context.Users
                             where users.Id == userId 

                             select new UserCodeDTO
                             {
                                 Id = users.Id,
                                 Code = users.Code,
                             };
                return await result.ToListAsync();
            }
        }
    }
}