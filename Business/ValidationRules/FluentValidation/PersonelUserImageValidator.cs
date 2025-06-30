using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonelUserImageValidator : AbstractValidator<PersonelUserImage>
    {
        public PersonelUserImageValidator()
        {
            RuleFor(c => c.ImageName).NotEmpty();
            RuleFor(c => c.ImageName).NotNull();
            RuleFor(c => c.ImageName).MinimumLength(2);

            RuleFor(c => c.ImagePath).NotEmpty();
            RuleFor(c => c.ImagePath).NotNull();
            RuleFor(c => c.ImagePath).MinimumLength(10);
        }
    }
}
