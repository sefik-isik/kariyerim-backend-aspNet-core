using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : BaseUser, IEntity
    {
        public int OperationClaimId { get; set; }
    }
}
