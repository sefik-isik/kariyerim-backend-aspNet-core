using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
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
                             join userOperationClaims in context.UserOperationClaims
                                 on operationClaims.Id equals userOperationClaims.OperationClaimId
                             where userOperationClaims.UserId == user.Id
                             select new OperationClaim { Id = operationClaims.Id, Name = operationClaims.Name };
                return result.ToList();

            }
        }

        public List<UserDTO> GetUserDTO()
        {
            using (var context = new KariyerimContext())
            {
                var result = from users in context.Users where users.DeletedDate==null
                             select new UserDTO { 
                                 Id = users.Id,
                                 Email = users.Email,
                             };
                return result.ToList();
            }
        }

        public List<UserDTO> GetUserDeletedDTO()
        {
            using (var context = new KariyerimContext())
            {
                var result = from users in context.Users where users.DeletedDate != null
                             select new UserDTO
                             {
                                 Id = users.Id,
                                 Email = users.Email,
                             };
                return result.ToList();
            }
        }
    }
}