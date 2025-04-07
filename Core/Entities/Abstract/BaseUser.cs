using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public abstract class BaseUser : Dto, IDto
    {
        public int UserId { get; set; }
    }
}
