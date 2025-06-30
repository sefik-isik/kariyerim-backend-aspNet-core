﻿using Core.Entities.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UniversityImage : BaseUniversity, IEntity
    {
        public string ImageName { get; set; }
        public string ImageOwnName { get; set; }
        public string ImagePath { get; set; }
        public bool isMainImage { get; set; }
        public bool isLogo { get; set; }
    }
}
