using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyUserAdvertJobDescription : BaseCompanyUserAdvert, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
