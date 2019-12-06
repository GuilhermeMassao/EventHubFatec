using EventHub.Domain.Input;
using FluentValidation;
using FluentValidation.Results;

namespace EventHub.Application.Services.UserApplication.Validations
{
    public class UserTwitterTokensInputValidation : AbstractValidator<UserTwitterTokensInput>
    {
        public ValidationResult Result { get; private set; }

        public bool IsValid(UserTwitterTokensInput input)
        {
            RuleFor(user => user.TwitterAccessToken)
                 .MaximumLength(200)
                 .WithMessage("Twitter Access Token inválido");

            RuleFor(user => user.TwitterAccessTokenSecret)
                 .MaximumLength(100)
                 .WithMessage("Twitter Access Token Secret inválido");

            Result = Validate(input);

            return Result.IsValid;
        }
    }
}
