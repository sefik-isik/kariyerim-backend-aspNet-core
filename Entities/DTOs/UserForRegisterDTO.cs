using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserForRegisterDTO : UserDTO, IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
