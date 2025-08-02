using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        Task<AccessToken> CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
