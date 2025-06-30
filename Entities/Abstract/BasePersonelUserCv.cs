using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public abstract class BasePersonelUserCv : BasePersonelUser, IEntity
    {
        public string CvId { get; set; }
    }
}
