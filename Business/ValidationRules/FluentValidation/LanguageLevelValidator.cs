using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LanguageLevelValidator : AbstractValidator<LanguageLevel>
    {
        public LanguageLevelValidator()
        {
            RuleFor(c => c.Level).GreaterThan(0);

            RuleFor(c => c.LevelTitle).NotEmpty();
            RuleFor(c => c.LevelTitle).NotNull();
            RuleFor(c => c.LevelTitle).MinimumLength(5);

            RuleFor(c => c.LevelDescription).NotEmpty();
            RuleFor(c => c.LevelDescription).NotNull();
            RuleFor(c => c.LevelDescription).MinimumLength(20);
        }
    }
}
