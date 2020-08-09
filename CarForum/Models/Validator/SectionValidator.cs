using FluentValidation;

namespace CarForum.Models.Validator
{
    public class SectionValidator : AbstractValidator<Section>
    {
        public SectionValidator()
        {
            RuleFor(x => x.SectionTitle).NotEmpty().MaximumLength(30).WithMessage("Enter a section title between 1 and 30 characters.");
        }
    }
}