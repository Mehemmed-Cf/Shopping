using FluentValidation;

namespace Shopping.Application.Modules.ColorsModule.Commands.ColorAddCommand
{
    public class ColorAddRequestValidatior : AbstractValidator<ColorAddRequest>
    {
        public ColorAddRequestValidatior()
        {
            var availables = new string[] { "A", "B", "C", "D", "E" };
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name bos buraxila bilmez")
                .NotNull().WithMessage("Name bos buraxila bilmez")
                .MinimumLength(2).WithMessage("EnAz 2 herf olmalidir");

            RuleFor(m => m.HexCode)
                .NotEmpty().WithMessage("HexCode bos buraxila bilmez")
                .NotNull().WithMessage("HexCode bos buraxila bilmez")
                .Matches("^#(([0-9a-fA-F]{6})|([0-9a-fA-F]{8}))$").WithMessage("Reng kodu standartlari odemir");


            RuleFor(m => m.State)
                .NotNull().WithMessage("State null buraxila bilmez")
                .NotEmpty().WithMessage("State bos buraxila bilmez")
                .Must((m, f) => {

                    if (!availables.Contains(f))
                    {
                        return false;
                    }

                    return true;
                })
                .WithMessage($"{string.Join(",", availables)} - variantlardan biri qeyd olunmalidir");
        }
    }
}
