using FluentValidation;

namespace CarForum.Models.Validator
{
    public class ForumValidator : AbstractValidator<Forum>
    {
        public ForumValidator()
        {
            RuleFor(x => x.ForumTitle).Length(3, 30).WithMessage("Enter a forum title between 3 and 30 characters.");
            RuleFor(x => x.ForumDesc).Length(3, 100).WithMessage("Enter a forum description between 3 and 100 characters.");
            RuleFor(x => x.ForumSection).NotNull().WithMessage("Enter with a section of forum");
        }
    }
}