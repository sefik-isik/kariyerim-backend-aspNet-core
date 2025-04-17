using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelUserDal : EfEntityRepositoryBase<PersonelUser, KariyerimContext>, IPersonelUserDal
    {
        public List<PersonelUserDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUsers in context.PersonelUsers
                             join users in context.Users on personelUsers.UserId equals users.Id

                             select new PersonelUserDTO
                             {
                                 Id = personelUsers.Id,
                                 UserId = users.Id,
                                 PersonelUserId = personelUsers.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 IdentityNumber = personelUsers.IdentityNumber,
                                 DateOfBirth = personelUsers.DateOfBirth,
                                 CreatedDate = personelUsers.CreatedDate,
                                 UpdatedDate = personelUsers.UpdatedDate,
                                 DeletedDate = personelUsers.DeletedDate,
                                 
                             };
                return result.ToList();
            }
        }

       
    }
}
