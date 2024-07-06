using FluentValidation;

namespace Shopping.Application.Modules.BrandsModule.Commands.BrandEditCommand
{
    public class BrandEditRequestValidator : AbstractValidator<BrandEditRequest>
    {
        public BrandEditRequestValidator()
        {
            RuleFor(m => m.Id)
            .GreaterThan(0).WithMessage("");
        }
    }
}
