using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class GenderValidator : AbstractValidator<Gender>
    {
        public GenderValidator()
        {
            RuleFor(c => c.GenderName).NotEmpty();
            RuleFor(c => c.GenderName).NotNull();
            RuleFor(c => c.GenderName).Length(5);
        }
    }
}
