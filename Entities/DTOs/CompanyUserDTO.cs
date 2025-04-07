using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyUserDTO : Dto, IDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public int TaxCityId { get; set; }
        public string TaxCityName { get; set; }
        public int TaxOfficeId { get; set; }
        public string TaxOfficeName { get; set; }
        public string TaxNumber { get; set; }

    }
}
