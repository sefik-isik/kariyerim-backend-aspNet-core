using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyUserSectorValidator : AbstractValidator<Sector>
    {
        public CompanyUserSectorValidator()
        {
            RuleFor(c => c.SectorName).NotEmpty();
            RuleFor(c => c.SectorName).NotNull();
            RuleFor(c => c.SectorName).MinimumLength(20);
        }
    }
}
