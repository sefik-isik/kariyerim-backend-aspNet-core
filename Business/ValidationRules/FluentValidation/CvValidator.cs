using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CvValidator : AbstractValidator<PersonelUserCv>
    {
        public CvValidator()
        {
            RuleFor(c => c.CvName).NotEmpty();
            RuleFor(c => c.CvName).NotNull();
            RuleFor(c => c.CvName).MinimumLength(2);

            RuleFor(c => c.LanguageId).GreaterThan(0);

            RuleFor(c => c.LanguageLevelId).GreaterThan(0);

            RuleFor(c => c.IsPrivate).NotEmpty();
            RuleFor(c => c.IsPrivate).NotNull();
        }
    }
}
