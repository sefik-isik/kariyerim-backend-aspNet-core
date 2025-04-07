using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WorkingMethodValidator : AbstractValidator<WorkingMethod>
    {
        public WorkingMethodValidator()
        {
            RuleFor(c => c.MethodName).NotEmpty();
            RuleFor(c => c.MethodName).NotNull();
            RuleFor(c => c.MethodName).MinimumLength(2);
        }
    }
}
