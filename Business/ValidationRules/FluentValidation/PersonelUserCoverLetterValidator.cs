using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonelUserCoverLetterValidator : AbstractValidator<PersonelUserCoverLetter>
    {
        public PersonelUserCoverLetterValidator()
        {
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Title).NotNull();
            RuleFor(c => c.Title).MinimumLength(2);

            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).NotNull();
            RuleFor(c => c.Description).MinimumLength(20);
        }
    }
}
