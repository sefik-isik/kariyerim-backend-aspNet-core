using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ModelMenu : Entity, IEntity
    {
        public string ModelName { get; set; }
    }
}
