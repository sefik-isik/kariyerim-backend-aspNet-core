using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserCvForeignLanguageDTO : BasePersonelUser, IDto
    {
        public int CvId { get; set; }
        public string CvName { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int LanguageLevelId { get; set; }
        public string LanguageLevelName { get; set; }
        public int Level { get; set; }
        public string LevelTitle { get; set; }
        public string LevelDescription { get; set; }
    }
}
