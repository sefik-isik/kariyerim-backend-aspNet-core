using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyUserImageDTO : BaseCompanyUserDTO, IDto
    {
        public string ImageName { get; set; }
        public string ImageOwnName { get; set; }
        public string ImagePath { get; set; }
        public bool IsMainImage { get; set; }
        public bool IsLogo { get; set; }
    }
}
