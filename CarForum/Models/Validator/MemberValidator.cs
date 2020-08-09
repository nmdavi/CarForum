using FluentValidation;
using FluentValidation.Validators;

namespace CarForum.Models.Validator
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(x => x.Username).NotEmpty().Length(3, 25).WithMessage("Enter a username between 3 and 25 characters.");
            RuleFor(x => x.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Invalid email.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Enter a password.");
            RuleFor(x => x.CustomTitle).Length(3, 25).NotEmpty().WithMessage("Enter a custom title between 6 and 25 characters.");
        }
    }
}