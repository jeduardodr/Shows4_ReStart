using System.ComponentModel.DataAnnotations;

namespace Shows4.App.Models;
public class AdultValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime dateOfBirth = (DateTime)value;
        var age = DateTime.Now.Year - dateOfBirth.Year;

        if (dateOfBirth > DateTime.Now.AddYears(-age))
        {
            age--;
        }

        if (age < 18 || age > 120)
        {
            return new ValidationResult(GetErrorMessage());
        }

        return ValidationResult.Success;
    }

    public string GetErrorMessage()
    {
       
        return ErrorMessage;
        
    }
}