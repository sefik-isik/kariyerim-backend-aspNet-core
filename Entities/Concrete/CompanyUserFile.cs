using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyUserFile : BaseCompanyUser, IEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

    }
}
