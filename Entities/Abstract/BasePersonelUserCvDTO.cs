using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public abstract class BasePersonelUserCvDTO : BasePersonelUserDTO, IDto
    {
        public string CvId { get; set; }
        public string CvName { get; set; }
    }
}
