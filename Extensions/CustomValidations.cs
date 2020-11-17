using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ActivityCenter.Extensions
{
    public class AgeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Please enter a date");
            }
            else if ((((DateTime)value).Year) > (DateTime.Now.Year -18))
            {
                return new ValidationResult("Must be 18+ years old.");
            }
            return ValidationResult.Success;
        }
    }

    public class DateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please enter a date");
            }
            else if ((DateTime)value < DateTime.Now.Date){
                return new ValidationResult("Must be a future date");
            }
            return ValidationResult.Success;
        }
    }

    public class PasswordValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please enter a password");
            }
            else
            {
                Regex PassVal = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*?[#?!@$%^&*-]){8,}$");
                MatchCollection match = PassVal.Matches((string)value);
                if (match.Count < 3)
                {
                return new ValidationResult("Password must include an upper-, lowercase, number, and special character");
                }
                else
                {
                return ValidationResult.Success;
                }
            }
        }
    }
}
