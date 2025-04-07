using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CvWorkExperienceValidator : AbstractValidator<PersonelUserCvWorkExperience>
    {
        public CvWorkExperienceValidator()
        {
            RuleFor(c => c.Position).NotEmpty();
            RuleFor(c => c.Position).NotNull();
            RuleFor(c => c.Position).MinimumLength(2);

            RuleFor(c => c.CompanyName).NotEmpty();
            RuleFor(c => c.CompanyName).NotNull();
            RuleFor(c => c.CompanyName).MinimumLength(2);

            RuleFor(c => c.Working).NotEmpty();
            RuleFor(c => c.Working).NotNull();

            RuleFor(c => c.StartDate).NotEmpty();
            RuleFor(c => c.StartDate).NotNull();

            RuleFor(c => c.EndDate).NotEmpty();
            RuleFor(c => c.EndDate).NotNull();

            RuleFor(c => c.CompanySectorId).GreaterThan(0);
            RuleFor(c => c.DepartmentId).GreaterThan(0);

            RuleFor(c => c.FoundJobInHere).NotEmpty();
            RuleFor(c => c.FoundJobInHere).NotNull();

            RuleFor(c => c.WorkingMethodId).GreaterThan(0);

            RuleFor(c => c.CountryId).GreaterThan(0);
            RuleFor(c => c.CityId).GreaterThan(0);
            RuleFor(c => c.RegionId).GreaterThan(0);

            RuleFor(c => c.Detail).NotEmpty();
            RuleFor(c => c.Detail).NotNull();
            RuleFor(c => c.Detail).MinimumLength(20);
        }
    }
}
