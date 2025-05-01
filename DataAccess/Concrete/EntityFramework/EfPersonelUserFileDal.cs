using Core.DataAccess.EntityFramework;
using Core.Utilities.Business.Constans;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelUserFileDal : EfEntityRepositoryBase<PersonelUserFile, KariyerimContext>,IPersonelUserFileDal
    {
        

        public List<PersonelUserFileDTO> GetAllDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserFiles in context.PersonelUserFiles
                             join personelUsers in context.PersonelUsers on personelUserFiles.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where users.Code == UserCodes.PersonelUserCode

                             select new PersonelUserFileDTO
                             {
                                 Id = personelUserFiles.Id,
                                 UserId = users.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 PhoneNumber = users.PhoneNumber,
                                 Code = users.Code,
                                 PersonelUserId = personelUsers.Id,
                                 FileName = personelUserFiles.FileName,
                                 FilePath = personelUserFiles.FilePath,
                                 CreatedDate = personelUserFiles.CreatedDate,
                                 UpdatedDate = personelUserFiles.UpdatedDate,
                                 DeletedDate = personelUserFiles.DeletedDate,
                             };
                return result.ToList();
            }
        }

        
    }


}
