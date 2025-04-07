using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonelUserFileValidator : AbstractValidator<PersonelUserFile>
    {
        public PersonelUserFileValidator()
        {
            RuleFor(c => c.PersonelUserId).GreaterThan(0);

            RuleFor(c => c.FileName).NotEmpty();
            RuleFor(c => c.FileName).NotNull();
            RuleFor(c => c.FileName).MinimumLength(2);

            RuleFor(c => c.FilePath).NotEmpty();
            RuleFor(c => c.FilePath).NotNull();
            RuleFor(c => c.FilePath).MinimumLength(2);
        }
    }
}
