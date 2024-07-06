using FluentValidation;

namespace Shopping.Application.Modules.BrandsModule.Commands.BrandAddCommand
{
    public class BrandAddRequestValidator : AbstractValidator<BrandAddRequest>
    {
        public BrandAddRequestValidator()
        {
            var availables = new string[] { "A", "B", "C", "D", "E" };
            RuleFor(m => m.Name)
                    .NotEmpty().WithMessage("Name bos buraxila bilmez")
                    .NotNull().WithMessage("Name bos buraxila bilmez")
                    .MinimumLength(2).WithMessage("EnAz 2 herf olmalidir");
        }
    }
}
