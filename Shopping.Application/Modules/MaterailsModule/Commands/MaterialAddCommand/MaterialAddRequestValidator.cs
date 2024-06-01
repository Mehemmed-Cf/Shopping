using FluentValidation;
using Shopping.Application.Modules.MaterailsModule.Commands.MaterialAddCommand;

namespace Shopping.Application.Modules.MaterialsModule.Commands.MaterialAddCommand
{
    public class MaterialAddRequestValidator : AbstractValidator<MaterialAddRequest>
    {
        public MaterialAddRequestValidator()
        {
            var availables = new string[] { "A", "B", "C", "D", "E" };
            RuleFor(m => m.Name)
                    .NotEmpty().WithMessage("Name bos buraxila bilmez")
                    .NotNull().WithMessage("Name bos buraxila bilmez")
                    .MinimumLength(2).WithMessage("EnAz 2 herf olmalidir");
        }
    }
}
