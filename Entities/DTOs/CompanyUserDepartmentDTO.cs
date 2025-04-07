﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyUserDepartmentDTO : BaseCompanyDTOUser, IDto
    {
        public string DepartmentName { get; set; }
    }
}
