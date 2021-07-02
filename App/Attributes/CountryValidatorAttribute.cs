using System;
using System.ComponentModel.DataAnnotations;
using Lib.Constants;

namespace App.Attributes
{
    public class CountryValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is not string stringValue || !IsValidCountry(stringValue))
            {
                return new ValidationResult(FormatErrorMessage(context.DisplayName));
            }

            return ValidationResult.Success;
        }

        private static bool IsValidCountry(string input)
        {
            return Enum.TryParse(typeof(Countries), input, true, out _);
        }
    }
}