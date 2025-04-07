using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WorkingMethod : Entity, IEntity
    {
        public string MethodName { get; set; }
    }
}
