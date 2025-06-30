using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public abstract class BaseUser : Entity, IEntity
    {
        public string UserId { get; set; }
        
    }
}
