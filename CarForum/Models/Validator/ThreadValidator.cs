using FluentValidation;

namespace CarForum.Models.Validator
{
    public class ThreadValidator : AbstractValidator<Thread>
    {
        public ThreadValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 100).WithMessage("Enter a title between 3 and 100 characters.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Thread text cannot be blank.");
            RuleFor(x => x.ThreadCreator).NotNull().WithMessage("Enter the thread creator.");
            RuleFor(x => x.ThreadForum).NotNull().WithMessage("Enter with a forum of thread.");
        }
    }
}