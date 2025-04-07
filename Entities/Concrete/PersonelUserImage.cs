using Core.Entities.Abstract;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PersonelUserImage : BasePersonelUser, IEntity
    {
        public string ImageName{ get; set; }
        public string ImagePath { get; set; }
    }
}
