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
            RuleFor(c => c.DepartmentName).NotEmpty();
            RuleFor(c => c.DepartmentName).NotNull();
            RuleFor(c => c.DepartmentName).MinimumLength(2);
        }
    }
}
