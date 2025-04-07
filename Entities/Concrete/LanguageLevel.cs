using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class LanguageLevel : Entity, IEntity
    {
        public int Level { get; set; }
        public string LevelTitle { get; set; }
        public string LevelDescription { get; set; }

    }
}
