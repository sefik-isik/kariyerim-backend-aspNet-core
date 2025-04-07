using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CvSummaryValidator : AbstractValidator<PersonelUserCvSummary>
    {
        public CvSummaryValidator()
        {
            RuleFor(c => c.CvId).GreaterThan(0);

            RuleFor(c => c.CVSummaryTitle).NotEmpty();
            RuleFor(c => c.CVSummaryTitle).NotNull();
            RuleFor(c => c.CVSummaryTitle).MinimumLength(2);

            RuleFor(c => c.CVSummaryDescription).NotEmpty();
            RuleFor(c => c.CVSummaryDescription).NotNull();
            RuleFor(c => c.CVSummaryDescription).MinimumLength(20);
        }
    }
}
