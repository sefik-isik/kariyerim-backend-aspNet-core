using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public abstract class BaseCv : Entity
    {
        public int UserId { get; set; }
        public int PersonelUserId { get; set; }
        public int CvId { get; set; }
    }
}
