using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserForRegisterDTO : Dto, IDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
    }
}
