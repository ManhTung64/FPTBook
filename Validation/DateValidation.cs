using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FPTBook.Validation
{
    public class DateValidation : ValidationAttribute
    {
        private const string FormatDate = "dd/MM/yy";
        private readonly DateTime date;
        private string today = DateTime.Now.Date.ToShortDateString();
        
        public DateValidation()
        {
            this.date = DateTime.ParseExact(today, FormatDate, CultureInfo.InvariantCulture);
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if ((DateTime)value >= date) return new ValidationResult(this.ErrorMessage);
            if ((int)value >= date.Year ) return new ValidationResult(this.ErrorMessage);
            return ValidationResult.Success;
        }
    }
}
