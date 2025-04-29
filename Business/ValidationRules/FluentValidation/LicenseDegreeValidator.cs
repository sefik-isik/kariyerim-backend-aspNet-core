using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LicenceDegreeValidator : AbstractValidator<LicenceDegree>
    {
        public LicenceDegreeValidator()
        {
            RuleFor(c => c.LicenceDegreeName).NotEmpty();
            RuleFor(c => c.LicenceDegreeName).NotNull();
            RuleFor(c => c.LicenceDegreeName).MinimumLength(2);
        }
    }
}
