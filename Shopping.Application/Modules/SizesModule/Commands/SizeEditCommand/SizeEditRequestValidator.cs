using FluentValidation;

namespace Shopping.Application.Modules.SizesModule.Commands.SizeEditCommand
{
    public class SizeEditRequestValidator : AbstractValidator<SizeEditRequest>
    {
        public SizeEditRequestValidator()
        {
            RuleFor(m => m.Id)
            .GreaterThan(0).WithMessage("");
        }
    }
}
