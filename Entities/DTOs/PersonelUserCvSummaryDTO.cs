using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserCvSummaryDTO : BasePersonelUserCvDTO, IDto
    {
        public string CvSummaryTitle { get; set; }
        public string CvSummaryDescription { get; set; }
    }
}
