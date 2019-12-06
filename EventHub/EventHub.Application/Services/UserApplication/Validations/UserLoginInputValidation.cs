using EventHub.Domain.Input;
using FluentValidation;
using FluentValidation.Results;

namespace EventHub.Application.Services.UserApplication.Validations
{
    public class UserLoginInputValidation : AbstractValidator<UserLoginInput>
    {
        public ValidationResult Result { get; private set; }

        public bool IsValid(UserLoginInput input)
        {
            RuleFor(user => user.Email)
                 .NotEmpty()
                 .WithMessage("Email inválido");

            RuleFor(user => user.UserPassword)
                .NotEmpty()
                .WithMessage("Senha inválido");

            Result = Validate(input);

            return Result.IsValid;
        }
    }
}
