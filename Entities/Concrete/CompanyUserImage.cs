using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyUserImage : BaseCompanyUser, IEntity
    {
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
