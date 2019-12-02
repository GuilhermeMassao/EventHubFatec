using EventHub.Application.Services.UserApplication.Input;
using FluentValidation;
using FluentValidation.Results;

namespace EventHub.Application.Services.UserApplication.Validations
{
    internal class UserInputValidation : AbstractValidator<UserInput>
    {
        public ValidationResult Result { get; private set; }

        public bool IsValid(UserInput input)
        {
            RuleFor(user => user.UserName)
                 .NotEmpty()
                 .MaximumLength(50)
                 .WithMessage("Nome inválido");

            RuleFor(user => user.Email)
                 .NotEmpty()
                 .MaximumLength(50)
                 .WithMessage("Email inválido");

            RuleFor(user => user.UserPassword)
                 .NotEmpty()
                 .Length(4, 15)
                 .WithMessage("Senha inválida");

            Result = Validate(input);

            return Result.IsValid;
        }
    }
}
