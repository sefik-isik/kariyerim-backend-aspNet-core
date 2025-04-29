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
            RuleFor(c => c.DriverLicenceName).NotEmpty();
            RuleFor(c => c.DriverLicenceName).NotNull();
            RuleFor(c => c.DriverLicenceName).MinimumLength(1);
        }
    }
}
