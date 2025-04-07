using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyUserValidator : AbstractValidator<CompanyUser>
    {
        public CompanyUserValidator()
        {
            RuleFor(c => c.UserId).GreaterThan(0);

            RuleFor(c => c.SectorId).GreaterThan(0);

            RuleFor(c => c.CompanyUserName).NotEmpty();
            RuleFor(c => c.CompanyUserName).NotNull();
            RuleFor(c => c.CompanyUserName).MinimumLength(2);

            RuleFor(c => c.TaxCityId).GreaterThan(0);
            RuleFor(c => c.TaxOfficeId).GreaterThan(0);

            RuleFor(c => c.TaxNumber).Length(10);
        }
    }
}
