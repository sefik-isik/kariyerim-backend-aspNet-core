using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class OperationClaim : Entity, IEntity
    {
        public string Name { get; set; }
    }
}
