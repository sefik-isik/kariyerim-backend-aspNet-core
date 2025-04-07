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
        public int ForeignLanguageId { get; set; }
        public bool IsPrivate { get; set; }

    }
}
