using FluentValidation;
using System;
using DomainModels.Dtos.ValidationExtensionsDto;
namespace DomainModels.Dtos
{
    public class ValidationDto : AbstractValidator<Customer>
    {
        public ValidationDto()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Full name must not be null or empty")
                .MinimumLength(10)
                .WithMessage("Full name lenght must  be more than 10 ");

            RuleFor(x => x)
                .NotEmpty()
                .Must(x => x.Email == x.EmailConfirmation)
                .WithMessage("Invalid email and email confirmation, please try again");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("CPF must not be null or empty")
                .Must(x => x.IsValidDocument())
                .MaximumLength(11)
                .WithMessage("CPF length must be a maximum of 11 numbers");

            RuleFor(x => x.Cellphone)
                .NotEmpty()
                .WithMessage("Cellphone must not be null or empty")
                .Must(x => x.IsValidCellPhone())
                .MaximumLength(11)
                .WithMessage("CellPhone length must be a maximum of 11 numbers");

            RuleFor(x => x.Birthdate)
                .NotEmpty()
                .WithMessage("Birth date must not be null or empty")
                .LessThan(DateTime.Now.Date)
                .WithMessage("Birth date must be older than today");

            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage("Country must not be null or empty");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City must not be null or empty");

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .Must(x => x.IsValidPostalCode())
                .MaximumLength(8)
                .WithMessage("The length of the Postal Code must be a maximum of 8 numbers");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address must not be null or empty");

            RuleFor(x => x.Number)
                .NotEmpty()
                .WithMessage("Number must not be null or empty");
        }
    }
}