using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UniversityDepartmentValidator : AbstractValidator<UniversityDepartment>
    {
        public UniversityDepartmentValidator()
        {
            RuleFor(c => c.UniversityId).GreaterThan(0);
            RuleFor(c => c.DepartmentId).GreaterThan(0);
            RuleFor(c => c.FacultyId).GreaterThan(0);
        }
    }
}
