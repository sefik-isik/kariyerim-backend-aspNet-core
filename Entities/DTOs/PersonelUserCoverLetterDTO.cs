using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserCoverLetterDTO: BasePersonelUserDTO,IDto
    {

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
