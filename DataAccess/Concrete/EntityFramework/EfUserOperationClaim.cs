using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaim : EfEntityRepositoryBase<UserOperationClaim, KariyerimContext>, IUserOperationClaimDal
    {
        public List<UserOperationClaimDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from userOperationClaims in context.UserOperationClaims
                             join users in context.Users on userOperationClaims.UserId equals users.Id
                             join operationClaims in context.OperationClaims on userOperationClaims.OperationClaimId equals operationClaims.Id

                             where userOperationClaims.DeletedDate == null
                             select new UserOperationClaimDTO
                             {
                                 Id = userOperationClaims.Id,
                                 UserId = userOperationClaims.UserId,
                                 Email = users.Email,
                                 OperationClaimId = userOperationClaims.OperationClaimId,
                                 OperationClaimName = operationClaims.Name,
                                 CreatedDate = userOperationClaims.CreatedDate,
                                 UpdatedDate = userOperationClaims.UpdatedDate,
                                 DeletedDate = userOperationClaims.DeletedDate,
                             };
                return result.ToList();
            }
        }

        public List<UserOperationClaimDTO> GetAllDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from userOperationClaims in context.UserOperationClaims
                             join users in context.Users on userOperationClaims.UserId equals users.Id
                             join operationClaims in context.OperationClaims on userOperationClaims.OperationClaimId equals operationClaims.Id

                             where userOperationClaims.DeletedDate != null 

                             select new UserOperationClaimDTO
                             {
                                 Id = userOperationClaims.Id,
                                 UserId = userOperationClaims.UserId,
                                 Email = users.Email,
                                 OperationClaimId = userOperationClaims.OperationClaimId,
                                 OperationClaimName = operationClaims.Name,
                                 CreatedDate = userOperationClaims.CreatedDate,
                                 UpdatedDate = userOperationClaims.UpdatedDate,
                                 DeletedDate = userOperationClaims.DeletedDate,
                             };
                return result.ToList();
            }
        }
    }
}
