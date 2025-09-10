using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyUserDTO : BaseUserDTO, IDto
    {
        public string CompanyUserName { get; set; }
        public string? ImageName { get; set; }
        public string? ImageOwnName { get; set; }
        public string? ImagePath { get; set; }
        public string SectorId { get; set; }
        public string SectorName { get; set; }
        public string About { get; set; }
        public string Clarification { get; set; }
        public string WorkerCountId { get; set; }
        public string WorkerCountValue { get; set; }
        public DateTime YearOfEstablishment { get; set; }
        public string WebAddress { get; set; }
        public string TaxCityId { get; set; }
        public string TaxCityName { get; set; }
        public string TaxOfficeId { get; set; }
        public string TaxOfficeName { get; set; }
        public string TaxNumber { get; set; }

    }
}
