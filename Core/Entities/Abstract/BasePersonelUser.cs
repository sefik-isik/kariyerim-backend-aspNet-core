﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public abstract class BasePersonelUser : BaseUser, IDto
    {
        public int PersonelUserId { get; set; }
    }
}
