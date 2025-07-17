using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Position : Entity, IEntity
    {
        public string PositionName { get; set; }
    }
}
