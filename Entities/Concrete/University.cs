using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class University : Entity, IEntity
    {
        public string UniversityName { get; set; }
        public string SectorId { get; set; }
        public DateTime YearOfEstablishment { get; set; }
        public string WorkerCount { get; set; }
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
