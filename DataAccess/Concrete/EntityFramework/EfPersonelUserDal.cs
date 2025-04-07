using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelUserDal : EfEntityRepositoryBase<PersonelUser, KariyerimContext>, IPersonelUserDal
    {
        public List<PersonelUserDTO> GetPersonelUserDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUsers in context.PersonelUsers
                             join users in context.Users on personelUsers.UserId equals users.Id
                             where personelUsers.DeletedDate==null
                             select new PersonelUserDTO
                             {
                                 Id = personelUsers.Id,
                                 UserId = users.Id,
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

        public List<PersonelUserDTO> GetPersonelUserDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUser in context.PersonelUsers
                             join user in context.Users on personelUser.UserId equals user.Id
                             where personelUser.DeletedDate != null
                             select new PersonelUserDTO
                             {
                                 Id = personelUser.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 PhoneNumber = user.PhoneNumber,
                                 IdentityNumber = personelUser.IdentityNumber,
                                 DateOfBirth = personelUser.DateOfBirth,
                                 CreatedDate = personelUser.CreatedDate,
                                 UpdatedDate = personelUser.UpdatedDate,
                                 DeletedDate = personelUser.DeletedDate,

                             };
                return result.ToList();
            }
        }
    }
}
