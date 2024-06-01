using MediatR;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.MaterailsModule.Commands.MaterialAddCommand
{
    public class MaterialAddRequest : IRequest<Material>
    {
        public string Name { get; set; }
    }
}
