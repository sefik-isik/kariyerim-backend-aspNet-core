using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyUserDepartmentValidator : AbstractValidator<CompanyUserDepartment>
    {
        public CompanyUserDepartmentValidator()
        {
            RuleFor(c => c.DepartmentId).NotEmpty();
            RuleFor(c => c.DepartmentId).NotNull();
            RuleFor(c => c.DepartmentId).MinimumLength(2);
        }
    }
}
