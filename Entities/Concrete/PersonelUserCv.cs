using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PersonelUserCv : BasePersonelUser, IEntity
    {
        public string CvName { get; set; }
        public string LanguageId { get; set; }
        public string LanguageLevelId { get; set; }
        public bool IsPrivate { get; set; }

    }
}
