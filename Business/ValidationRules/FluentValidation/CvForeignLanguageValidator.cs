using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CvForeignLanguageValidator : AbstractValidator<PersonelUserCvForeignLanguage>
    {
        public CvForeignLanguageValidator()
        {
            RuleFor(c => c.CvId).GreaterThan(0);
            RuleFor(c => c.LanguageId).GreaterThan(0);
            RuleFor(c => c.LanguageLevelId).GreaterThan(0);
        }
    }
}
