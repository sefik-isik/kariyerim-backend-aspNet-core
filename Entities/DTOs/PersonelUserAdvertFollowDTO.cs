using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelUserAdvertFollowDTO : BaseAdvertDTO, IDto
    {
        public string? AdvertId { get; set; }
        public string? AdvertName { get; set; }
    }
}
