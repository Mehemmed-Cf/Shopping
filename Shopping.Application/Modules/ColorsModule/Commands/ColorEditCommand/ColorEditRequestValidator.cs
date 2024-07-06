using FluentValidation;

namespace Shopping.Application.Modules.ColorsModule.Commands.ColorEditCommand
{
    class ColorEditRequestValidator : AbstractValidator<ColorEditRequest>
    {
        public ColorEditRequestValidator()
        {
            RuleFor(m => m.Id)
            .GreaterThan(0).WithMessage("");
        }
    }
}
