using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models.CustomValidations
{
    public class MyValidationMethods
    {
        public static ValidationResult FirstLetterCapital(string value, ValidationContext context)
        {
            bool IsValid = true; // we start with an obligation that everything is fine!!!

            if (value != null) // if the string is not empty
            {
                if (char.IsLower(value[0]))
                {
                    IsValid = false;
                }
            }
            

            if (IsValid )
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"The field {context.MemberName} First Letter must be Capital",new List<string> {context.MemberName});
            }
            
        }


        public static ValidationResult LengthMin(string value, ValidationContext context)
        {
            bool IsValid = true; // we start with an obligation that everything is fine!!!

            if (value != null) // if the string is not empty
            {
                if (value.Length < 10) 
                {
                    IsValid = false;
                }
            }


            if (IsValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"The field {context.MemberName} Your input text is under 10 characters", new List<string> { context.MemberName });
            }

        }

        public static ValidationResult LengthMax(string value, ValidationContext context)
        {
            bool IsValid = true; // we start with an obligation that everything is fine!!!

            if (value != null) // if the string is not empty
            {
                if (value.Length > 50) 
                {
                    IsValid = false;
                }
            }


            if (IsValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"The field {context.MemberName} Your input text is over 50 characters", new List<string> { context.MemberName });
            }

        }
    }
}