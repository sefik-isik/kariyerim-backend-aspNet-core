using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UniversityValidator : AbstractValidator<University>
    {
        public UniversityValidator()
        {
            RuleFor(c => c.UniversityName).NotEmpty();
            RuleFor(c => c.UniversityName).NotNull();
            RuleFor(c => c.UniversityName).MinimumLength(20);
        }
    }
}
