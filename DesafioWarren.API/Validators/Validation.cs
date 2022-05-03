using DesafioWarren.API.Models;
using FluentValidation;

namespace DesafioWarren.API.Validators
{
    public class Validation : AbstractValidator<Cadastro>
    {
        public Validation()
        {
            RuleFor(v => v.fullName).NotEmpty()
                .WithMessage("Full name must not be null or empty")
                .MinimumLength(10)
                .WithMessage("Full name lenght must  be more than 10 ");

            RuleFor(v => v.email).NotEmpty()
                .WithMessage("Email must not be null or empty")
                .EmailAddress()
                .WithMessage("Enter a valid email");

            RuleFor(v => v.emailConfirmation).NotEmpty()
                .WithMessage("EmailConfirmation must not be null or empty")
                .EmailAddress()
                .WithMessage("Enter a valid email");

            RuleFor(v => v.cpf).NotEmpty()
                .WithMessage("CPF must not be null or empty")
                .Must(c => c.IsValidDocument())
                .Length(14)
                .WithMessage("Enter a valid CPF");

            RuleFor(v => v.cellphone).NotEmpty()

                .WithMessage("Cellphone must not be null or empty")
                .Must(c => c.IsValidCellPhone())
                .MaximumLength(11)
                .WithMessage("Put a valid number");

            RuleFor(v => v.birthdate).NotEmpty()
                .WithMessage("Birth date must not be null or empty")
                .LessThan(DateTime.Now.Date)
                .WithMessage("Birth date must be older than today");

            RuleFor(v => v.country).NotEmpty()
                .WithMessage("Country must not be null or empty");

            RuleFor(v => v.city).NotEmpty()
                .WithMessage("City must not be null or empty");

            RuleFor(v => v.postalCode).NotEmpty()
                .Must(c => c.IsValidPostalCode())
                .MaximumLength(8)
                .WithMessage("The maximum is 8");

            RuleFor(v => v.address).NotEmpty()
                .WithMessage("Address must not be null or empty");

            RuleFor(v => v.number).NotEmpty()
                .WithMessage("Number must not be null or empty");
    
        }
        public static bool ValidateEmail(Cadastro cdt)
        {
            if (cdt.email == cdt.emailConfirmation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
