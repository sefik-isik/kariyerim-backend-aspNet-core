using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class DriverLicenseValidator : AbstractValidator<DriverLicense>
    {
        public DriverLicenseValidator()
        {
            RuleFor(c => c.LicenseName).NotEmpty();
            RuleFor(c => c.LicenseName).NotNull();
            RuleFor(c => c.LicenseName).MinimumLength(1);
        }
    }
}
