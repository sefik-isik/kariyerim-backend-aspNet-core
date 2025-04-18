using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class DriverLicenceValidator : AbstractValidator<DriverLicence>
    {
        public DriverLicenceValidator()
        {
            RuleFor(c => c.LicenceName).NotEmpty();
            RuleFor(c => c.LicenceName).NotNull();
            RuleFor(c => c.LicenceName).MinimumLength(1);
        }
    }
}
