using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FacultyValidator : AbstractValidator<Faculty>
    {
        public FacultyValidator()
        {
            RuleFor(c => c.FacultyName).NotEmpty();
            RuleFor(c => c.FacultyName).NotNull();
            RuleFor(c => c.FacultyName).MinimumLength(2);
        }
    }
}
