using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserCvSummaryDTO : BasePersonelDTOUser, IDto
    {
        public int CvId { get; set; }
        public string CvName { get; set; }
        public string CvSummaryTitle { get; set; }
        public string CvSummaryDescription { get; set; }
    }
}
