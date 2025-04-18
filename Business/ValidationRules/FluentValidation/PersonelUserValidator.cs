using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonelUserValidator : AbstractValidator<PersonelUser>
    {
        public PersonelUserValidator()
        {
            RuleFor(c => c.UserId).GreaterThan(0);

            RuleFor(c => c.LicenceId).GreaterThan(0);
            RuleFor(c => c.BirthPlaceId).GreaterThan(0);

            RuleFor(c => c.DateOfBirth).NotEmpty();
            RuleFor(c => c.DateOfBirth).NotNull();
        }
    }
}
