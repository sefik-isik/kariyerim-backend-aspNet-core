using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(c => c.LanguageName).NotEmpty();
            RuleFor(c => c.LanguageName).NotNull();
            RuleFor(c => c.LanguageName).MinimumLength(2);
        }
    }
}
