using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Application.UsersApi.Commands
{
    /// <summary>
    /// CreateUser command validator
    /// </summary>

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .Length(3, 50);
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(6, 30);
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
