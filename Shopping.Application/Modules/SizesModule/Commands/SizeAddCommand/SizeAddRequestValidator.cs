using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.SizesModule.Commands.SizeAddCommand
{
    public class SizeAddRequestValidator : AbstractValidator<SizeAddRequest>
    {
        public SizeAddRequestValidator()
        {
            var availables = new string[] { "A", "B", "C", "D", "E" };

            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name bos buraxila bilmez")
                .NotNull().WithMessage("Name bos buraxila bilmez")
                .MinimumLength(2).WithMessage("En Az 2 herf olmalidir");
        }
    }
}
