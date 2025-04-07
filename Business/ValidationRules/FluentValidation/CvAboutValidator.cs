using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CvAboutValidator : AbstractValidator<PersonelUserCvAbout>
    {
        public CvAboutValidator()
        {
            RuleFor(c => c.CvId).GreaterThan(0);
            RuleFor(c => c.GenderId).GreaterThan(0);

            RuleFor(c => c.NationalStatus).NotEmpty();
            RuleFor(c => c.NationalStatus).NotNull();
            RuleFor(c => c.DriverLicenseId).GreaterThan(0);

            RuleFor(c => c.MilitaryStatus).NotEmpty();
            RuleFor(c => c.MilitaryStatus).NotNull();

            RuleFor(c => c.RetirementStatus).NotEmpty();
            RuleFor(c => c.RetirementStatus).NotNull();

        }
    }
}
