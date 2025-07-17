using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UniversityDTO : Dto, IDto
    {
        public string UniversityName { get; set; }
        public string SectorId { get; set; }
        public string SectorName { get; set; }
        public DateTime YearOfEstablishment { get; set; }
        public string WorkerCountId { get; set; }
        public string WorkerCountValue { get; set; }
        public string WebAddress { get; set; }
        public string WebNewsAddress { get; set; }
        public string YouTubeEmbedAddress { get; set; }
        public string Address { get; set; }
        public string FacebookAddress { get; set; }
        public string InstagramAddress { get; set; }
        public string XAddress { get; set; }
        public string YouTubeAddress { get; set; }
        public string Description { get; set; }
        public string SubDescription { get; set; }
    }
}
