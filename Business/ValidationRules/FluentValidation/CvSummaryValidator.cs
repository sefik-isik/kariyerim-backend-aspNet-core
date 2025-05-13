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

            RuleFor(c => c.CvSummaryTitle).NotEmpty();
            RuleFor(c => c.CvSummaryTitle).NotNull();
            RuleFor(c => c.CvSummaryTitle).MinimumLength(2);

            RuleFor(c => c.CvSummaryDescription).NotEmpty();
            RuleFor(c => c.CvSummaryDescription).NotNull();
            RuleFor(c => c.CvSummaryDescription).MinimumLength(20);
        }
    }
}
