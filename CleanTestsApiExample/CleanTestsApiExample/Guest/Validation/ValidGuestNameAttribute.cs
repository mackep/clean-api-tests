using System.ComponentModel.DataAnnotations;

namespace CleanTestsApiExample.Guest.Validation
{
    public class ValidGuestNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is string str && !string.IsNullOrWhiteSpace(str) && str.Length < 100;
        }
    }
}