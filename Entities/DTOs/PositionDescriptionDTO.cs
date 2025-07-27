using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PositionDescriptionDTO : Dto, IDto
    {
        public string PositionId { get; set; }
        public string PositionName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
