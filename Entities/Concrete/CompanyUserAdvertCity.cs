using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyUserAdvertCity : BaseCompanyUserAdvert, IEntity
    {
        public string WorkCityId { get; set; }
    }
}
