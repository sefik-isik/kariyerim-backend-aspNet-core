using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public abstract class BaseAdvertDTO : Dto, IDto
    {
        public string? CompanyUserId { get; set; }
        public string? CompanyUserName { get; set; }
        public string? PersonelUserId { get; set; }
        public string? PersonelUserMail { get; set; }
        public string? PersonelUserFirstName { get; set; }
        public string? PersonelUserLastName { get; set; }
        public string? PersonelUserPhoneNumber { get; set; }
        public string? PersonelUserTitle { get; set; }
        public bool? PersonelUserGender { get; set; }
        public DateTime? PersonelUserDateOfBirth { get; set; }
        public bool? PersonelUserNationalStatus { get; set; }
        public bool? PersonelUserMilitaryStatus { get; set; }
        public bool? PersonelUserRetirementStatus { get; set; }
        public string? PersonelUserCvId { get; set; }
        public string? PersonelUserCvName { get; set; }
        public string? PersonelUserImageName { get; set; }
        public string? PersonelUserImageOwnName { get; set; }
        public string? PersonelUserImagePath { get; set; }
        public string? CompanyUserImageName { get; set; }
        public string? CompanyUserImageOwnName { get; set; }
        public string? CompanyUserImagePath { get; set; }
    }
}
