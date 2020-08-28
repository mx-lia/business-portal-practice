using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.UsersApi.Commands
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.UserName)
                .NotEmpty()
                .Length(3, 50);
            
            // if we need to check old password for confirmation
            //RuleFor(x => x.OldPassword)
            //    .NotEmpty()
            //    .Length(6, 30);
        }
    }
}
