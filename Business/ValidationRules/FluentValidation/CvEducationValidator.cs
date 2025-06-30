using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CvEducationValidator : AbstractValidator<PersonelUserCvEducation>
    {
        public CvEducationValidator()
        {
            RuleFor(c => c.EducationInfo).NotEmpty();
            RuleFor(c => c.EducationInfo).NotNull();
            RuleFor(c => c.EducationInfo).MinimumLength(20);

            RuleFor(c => c.StartDate).NotEmpty();
            RuleFor(c => c.StartDate).NotNull();

            RuleFor(c => c.EndDate).NotEmpty();
            RuleFor(c => c.EndDate).NotNull();

            RuleFor(c => c.Abandonment).NotEmpty();
            RuleFor(c => c.Abandonment).NotNull();

            RuleFor(c => c.Detail).NotEmpty();
            RuleFor(c => c.Detail).NotNull();
            RuleFor(c => c.Detail).MinimumLength(20);

        }
    }
}
