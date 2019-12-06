using EventHub.Domain.Input;
using FluentValidation;
using FluentValidation.Results;

namespace EventHub.Application.Services.UserApplication.Validations
{
    public class GoogleRefreshTokenInputValidation : AbstractValidator<GoogleRefreshTokenInput>
    {
        public ValidationResult Result { get; private set; }

        public bool IsValid(GoogleRefreshTokenInput input)
        {
            RuleFor(user => user.RefreshToken)
                 .MaximumLength(200)
                 .WithMessage("Google Refresh Token inválido");

            Result = Validate(input);

            return Result.IsValid;
        }
    }
}
