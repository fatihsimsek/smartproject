using System;
using System.Data;
using FluentValidation;

namespace SmartProject.Application.Identity
{
	public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
	{
		public UserLoginCommandValidator()
		{
            ValidateEmail();
            ValidatePassword();
		}

        private void ValidateEmail()
        {
            RuleFor(command => command.Email)
                .Must(email => !string.IsNullOrWhiteSpace(email))
                .WithSeverity(Severity.Error)
                .WithMessage("Email cannot be empty");
        }

        private void ValidatePassword()
        {
            RuleFor(command => command.Password)
                .Must(password => !string.IsNullOrWhiteSpace(password))
                .WithSeverity(Severity.Error)
                .WithMessage("Password cannot be empty");
        }
    }
}

