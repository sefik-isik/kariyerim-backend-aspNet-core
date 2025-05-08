using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public abstract class BasePersonelUser : Entity, IEntity
    {
        public int PersonelUserId { get; set; }
    }
}
