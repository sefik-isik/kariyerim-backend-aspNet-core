using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(c => c.CountryName).NotEmpty();
            RuleFor(c => c.CountryName).NotNull();
            RuleFor(c => c.CountryName).MinimumLength(20);
        }
    }
}
