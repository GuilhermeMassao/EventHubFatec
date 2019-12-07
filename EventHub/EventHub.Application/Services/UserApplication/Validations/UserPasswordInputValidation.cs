using EventHub.Domain.Input;
using FluentValidation;
using FluentValidation.Results;

namespace EventHub.Application.Services.UserApplication.Validations
{
    internal class UserPasswordInputValidation : AbstractValidator<UserPasswordInput>
    {
        public ValidationResult Result { get; private set; }

        public bool IsValid(UserPasswordInput input)
        {
            RuleFor(user => user.OldPassword)
                 .NotEmpty()
                 .MaximumLength(15)
                 .WithMessage("Senha antiga inválida");

            RuleFor(user => user.NewPassword)
                 .NotEmpty()
                 .MaximumLength(15)
                 .WithMessage("Senha nova inválida");

            Result = Validate(input);

            return Result.IsValid;
        }
    }
}
