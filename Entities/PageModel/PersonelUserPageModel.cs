using Core.Entities.Concrete;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageModel
{
    public class PersonelUserPageModel :PageModel
    {
        public List<PersonelUserDTO>? PageContacts { get; set; }
        public string? Filter { get; set; }
    }
}
