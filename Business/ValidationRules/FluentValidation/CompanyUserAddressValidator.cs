using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyUserAddressValidator : AbstractValidator<CompanyUserAddress>
    {
        public CompanyUserAddressValidator()
        {
            RuleFor(c => c.CompanyUserId).GreaterThan(0);
            RuleFor(c => c.CountryId).GreaterThan(0);
            RuleFor(c => c.CityId).GreaterThan(0);
            RuleFor(c => c.RegionId).GreaterThan(0);

            RuleFor(c => c.AddressDetail).NotEmpty();
            RuleFor(c => c.AddressDetail).NotNull();
            RuleFor(c => c.AddressDetail).MinimumLength(50);
            RuleFor(c => c.AddressDetail).MaximumLength(250);
        }
    }
}
