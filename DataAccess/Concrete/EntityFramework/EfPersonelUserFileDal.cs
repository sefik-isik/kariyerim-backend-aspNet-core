using Core.DataAccess.EntityFramework;
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
        

        public List<PersonelUserFileDTO> GetPersonelUserFileDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserFiles in context.PersonelUserFiles
                             join personelUsers in context.PersonelUsers on personelUserFiles.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where personelUserFiles.DeletedDate == null
                             select new PersonelUserFileDTO
                             {
                                 Id = personelUserFiles.Id,
                                 UserId = users.Id,
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

        public List<PersonelUserFileDTO> GetPersonelUserFileDeletedDTO()
        {
            using (KariyerimContext context = new KariyerimContext())
            {
                var result = from personelUserFiles in context.PersonelUserFiles
                             join personelUsers in context.PersonelUsers on personelUserFiles.PersonelUserId equals personelUsers.Id
                             join users in context.Users on personelUsers.UserId equals users.Id

                             where personelUserFiles.DeletedDate != null
                             select new PersonelUserFileDTO
                             {
                                 Id = personelUserFiles.Id,
                                 UserId = users.Id,
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
