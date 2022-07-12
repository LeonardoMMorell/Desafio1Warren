using AppServices.Dtos;
using FluentValidation;
using FluentValidation.Validators;
using System;

namespace AppServices.Validators
{
    public class CustomerCreateValidation : AbstractValidator<CreateCustomerRequest>
    {
        public CustomerCreateValidation()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .NotNull()
                .Must(x => x.IsValidFullName())
                .MaximumLength(300)
                .MinimumLength(2);

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress(EmailValidationMode.Net4xRegex);

            RuleFor(x => x.EmailConfirmation.Equals(x.Email));

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .Must(ValidateCpf)
                .Length(11);

            RuleFor(x => x.Cellphone)
                .NotEmpty()
                .NotNull()
                .Must(x => x.OnlyNumbers())
                .Length(11);

            RuleFor(x => x.Birthdate)
                .NotEmpty()
                .NotNull()
                .Must(x => x.ApproveAge())
                .LessThan(DateTime.Now.Date);

            RuleFor(x => x.Country)
                .NotNull()
                .Must(x => x.OnlyLetters())
                .NotEmpty();

            RuleFor(x => x.City)
                .NotNull()
                .Must(x => x.OnlyLetters())
                .NotEmpty();

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .NotNull()
                .Must(x => x.OnlyNumbers())
                .Length(8);

            RuleFor(x => x.Address)
                .NotNull()
                .Must(x => x.OnlyLetters())
                .NotEmpty();

            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty();
        }

        private static bool ValidateCpf(string cpf)
        {
            var firstDigitAfterDash = 0;
            for (int i = 0; i < cpf.Length - 2; i++)
            {
                firstDigitAfterDash += cpf.ToIntAt(i) * (10 - i);
            }
            firstDigitAfterDash = (firstDigitAfterDash * 10) % 11;

            var secondDigitAfterDash = 0;
            for (int i = 0; i < cpf.Length - 1; i++)
            {
                secondDigitAfterDash += cpf.ToIntAt(i) * (11 - i);
            }
            secondDigitAfterDash = (secondDigitAfterDash * 10) % 11;

            return firstDigitAfterDash == cpf.ToIntAt(^2) && secondDigitAfterDash == cpf.ToIntAt(^1);
        }
    }
}