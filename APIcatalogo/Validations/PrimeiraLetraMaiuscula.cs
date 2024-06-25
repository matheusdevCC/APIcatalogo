using System.ComponentModel.DataAnnotations;

namespace APIcatalogo.Validations
{
    public class PrimeiraLetraMaiuscula : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;      
            }

            var PrimeiraLetra = value.ToString()[0].ToString();

            if(PrimeiraLetra != PrimeiraLetra.ToUpper()) 
            {
                return new ValidationResult("A primeira letra do nome do produto deve ser maiúscula!");
            }
            return ValidationResult.Success;
        }

       
    }
}
