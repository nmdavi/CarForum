using FluentValidation;

namespace CarForum.Models.Validator
{
    public class ReplyValidator : AbstractValidator<Reply>
    {
        public ReplyValidator()
        {
            RuleFor(x => x.ReplyText).NotEmpty().WithMessage("Enter a section title between 1 and 30 characters.");
            RuleFor(x => x.ReplyCreator).NotNull().WithMessage("Enter the reply creator.");
            RuleFor(x => x.ReplyThread).NotNull().WithMessage("Enter a thread.");
        }
    }
}