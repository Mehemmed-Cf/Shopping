using FluentValidation;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.MaterialsModule.Commands.MaterialEditCommand
{
    public class MaterialEditRequestValidator : AbstractValidator<MaterialEditRequest>
    {
        public MaterialEditRequestValidator()
        {
            RuleFor(m => m.Id)
            .GreaterThan(0).WithMessage("");
        }
    }
}
