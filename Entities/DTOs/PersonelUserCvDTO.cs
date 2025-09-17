using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserCvDTO : BasePersonelUserCvDTO, IDto
    {
        public string LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LanguageLevelId { get; set; }
        public int Level { get; set; }
        public string LevelTitle { get; set; }
        public string LevelDescription { get; set; }
        public string BirthPlaceId { get; set; }
        public string BirthPlaceName { get; set; }
        public bool IsPrivate { get; set; }
    }
}
