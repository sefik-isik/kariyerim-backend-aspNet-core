using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyUserAdvertJobDescriptionDTO : BaseCompanyUserAdvertDTO, IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
