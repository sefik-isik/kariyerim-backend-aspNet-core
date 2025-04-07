using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserCvDTO : BasePersonelDTOUser, IDto
    {
        public string CvName { get; set; }
        public int ForeignLanguageId { get; set; }
        public bool IsPrivate { get; set; }
    }
}
