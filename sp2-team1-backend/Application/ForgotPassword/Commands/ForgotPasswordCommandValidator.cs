using FluentValidation;

namespace Application.ForgotPassword.Commands
{
    class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty();
        }
    }
}
