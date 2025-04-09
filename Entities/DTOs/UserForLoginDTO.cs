using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserForLoginDTO : UserDTO, IDto
    {
        public string Password { get; set; }
    }
}
