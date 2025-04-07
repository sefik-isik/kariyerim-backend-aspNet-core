using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PersonelUserCvSummary : BaseCv, IEntity
    {
        public string CVSummaryTitle { get; set; }
        public string CVSummaryDescription { get; set; }

    }
}
