using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonelUserAddressValidator : AbstractValidator<PersonelUserAddress>
    {
        public PersonelUserAddressValidator()
        {
            RuleFor(c => c.AddressDetail).NotEmpty();
            RuleFor(c => c.AddressDetail).NotNull();
            RuleFor(c => c.AddressDetail).MinimumLength(20);
        }
    }
}
