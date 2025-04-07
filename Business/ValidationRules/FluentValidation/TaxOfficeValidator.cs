using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class TaxOfficeValidator : AbstractValidator<TaxOffice>
    {
        public TaxOfficeValidator()
        {
            RuleFor(c => c.TaxOfficeName).NotEmpty();
            RuleFor(c => c.TaxOfficeName).NotNull();
            RuleFor(c => c.TaxOfficeName).MinimumLength(2);
        }
    }
}
