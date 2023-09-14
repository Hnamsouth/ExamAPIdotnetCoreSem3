using System;
using System.ComponentModel.DataAnnotations;

namespace ExamAPI.Validations
{
    public class GreaterThanOld : ValidationAttribute
    {

        private readonly int _minAge;

        public GreaterThanOld(int minAge)
        {
            _minAge = minAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var today = DateTime.Today;
                var age = today.Year - dateOfBirth.Year;

                if (dateOfBirth > today.AddYears(-age)) age--;

                if (age < _minAge)
                {
                    return new ValidationResult($" Your DOB must be greaterthan {_minAge}.");
                }
            }

            return ValidationResult.Success;
        }

    }
}
