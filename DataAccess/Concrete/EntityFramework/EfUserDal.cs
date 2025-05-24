using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Business.Constans;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, KariyerimContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new KariyerimContext())
            {
                var result = from operationClaims in context.OperationClaims
                             join userOperationClaims in context.UserOperationClaims on operationClaims.Id equals userOperationClaims.OperationClaimId
                             join users in context.Users on userOperationClaims.UserId equals users.Id


                             where userOperationClaims.UserId == user.Id 

                             select new OperationClaim { Id = operationClaims.Id, Name = operationClaims.Name };
                return result.ToList();

            }
        }

        public List<UserDTO> GetAllDTO()
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
                return result.ToList();
            }
        }

        public List<UserDTO> GetAllCompanyUserDTO()
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
                return result.ToList();
            }
        }

        public List<UserDTO> GetAllPersonelUserDTO()
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
                return result.ToList();
            }
        }

        public List<UserDTO> GetDeletedAllDTO()
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
                return result.ToList();
            }
        }

        public UserDTO GetByIdForAdminDTO(int id)
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
                return result.ToList()[0];
            }
        }

        public UserDTO GetByIdDTO(int userId, int id)
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
                return result.ToList()[0];
            }
        }
        public List<UserCodeDTO> GetCode(int userId)
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
                return result.ToList();
            }
        }
    }
}