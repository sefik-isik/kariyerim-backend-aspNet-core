using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyUser : BaseUser, IEntity
    {
        public string CompanyUserName { get; set; }
        public string About { get; set; }
        public string Clarification { get; set; }
        public string WorkerCountId { get; set; }
        public DateTime YearOfEstablishment { get; set; }
        public string WebAddress { get; set; }
        public string SectorId { get; set; }
        public string TaxCityId { get; set; }
        public string TaxOfficeId { get; set; }
        public string TaxNumber { get; set; }
    }
}
