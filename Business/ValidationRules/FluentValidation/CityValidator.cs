using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CityValidator : AbstractValidator<City>
    {

        public CityValidator()
        {

            RuleFor(c => c.CityName).NotEmpty();
            RuleFor(c => c.CityName).NotNull();
            RuleFor(c => c.CityName).MinimumLength(3);
            RuleFor(c => c.CityName).Must(NotStartsWithThisCharacters).When(c=>c.CountryId== "48e4c8f0-81fd-4247-8dad-75312de17e4f").WithMessage("Şehir ismi bu karekterle başlayamaz");
            RuleFor(c => c.CityName).Must(NotContainCharacters).When(c=>c.CountryId== "48e4c8f0-81fd-4247-8dad-75312de17e4f").WithMessage("Şehir ismi bu karekterleri içeremez");
        }

        private bool NotStartsWithThisCharacters(string arg)
        {
            List<string> characters = new List<string> { "J", "Ğ", "X", "W", "Q", "j", "ğ", "x", "w", "q" };

            foreach (var character in characters)
            {
                if (arg.StartsWith(character))
                {
                    return false;
                }
            }
            return true;
        }

        private bool NotContainCharacters(string arg)
        {
            List<string> characters = new List<string> { "J", "Ğ", "X", "W", "Q", "j", "ğ", "x", "w", "q" };

            foreach (var character in characters)
            {
                if (arg.Contains(character))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
