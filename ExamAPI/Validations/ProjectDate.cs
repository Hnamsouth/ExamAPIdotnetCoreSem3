using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ExamAPI.Validations
{
    public class ProjectDate : ValidationAttribute
    {

        private readonly string _startdate;

        public ProjectDate(string startdate)
        {
            _startdate= startdate;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime enddate)
            {
                var startdatecheck = validationContext.ObjectType.GetProperty(_startdate);

                if (startdatecheck == null)
                {
                    throw new ArgumentException($"{startdatecheck} not exists.");
                }

                var startdate = startdatecheck.GetValue(validationContext.ObjectInstance);

                if (enddate.CompareTo(startdate)>0)
                {
                    return new ValidationResult(ErrorMessage ?? $"{startdate} later than {validationContext.DisplayName}.");
                }
            }

               

            return ValidationResult.Success;
        }
    }
}
