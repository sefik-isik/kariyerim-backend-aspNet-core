using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RegionValidator : AbstractValidator<Region>
    {
        public RegionValidator()
        {
            RuleFor(c => c.CityId).GreaterThan(0);

            RuleFor(c => c.RegionName).NotEmpty();
            RuleFor(c => c.RegionName).NotNull();
            RuleFor(c => c.RegionName).MinimumLength(2);
        }
    }
}
