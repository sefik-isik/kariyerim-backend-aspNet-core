using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LicenseDegreeValidator : AbstractValidator<LicenseDegree>
    {
        public LicenseDegreeValidator()
        {
            RuleFor(c => c.LicenceName).NotEmpty();
            RuleFor(c => c.LicenceName).NotNull();
            RuleFor(c => c.LicenceName).MinimumLength(2);
        }
    }
}
