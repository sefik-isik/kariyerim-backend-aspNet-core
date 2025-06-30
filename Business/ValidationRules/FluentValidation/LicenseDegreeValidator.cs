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
            RuleFor(c => c.LicenseDegreeName).NotEmpty();
            RuleFor(c => c.LicenseDegreeName).NotNull();
            RuleFor(c => c.LicenseDegreeName).MinimumLength(2);
        }
    }
}
