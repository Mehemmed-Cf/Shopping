using MediatR;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.BrandsModule.Commands.BrandAddCommand
{
    public class BrandAddRequest : IRequest<Brand>
    {
        public string Name { get; set; }
    }
}
