using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Shared.Constants;

namespace Application.Users.Commands.AddNewUser
{
    public class AddNewUserCommandValidator : AbstractValidator<AddNewUserCommand>
    {
        public AddNewUserCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithName(ExceptionMessage.DOMAIN_USER_NAME_INVALID);

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage(ExceptionMessage.DOMAIN_USER_EMAIL_INVALID)
                .EmailAddress().WithMessage(ExceptionMessage.DOMAIN_USER_EMAIL_FORMAT_INVALID);

            RuleFor(e => e.Password)
                .NotEmpty().WithName(ExceptionMessage.DOMAIN_USER_PASSWORD_INVALID);
        }
    }
}
