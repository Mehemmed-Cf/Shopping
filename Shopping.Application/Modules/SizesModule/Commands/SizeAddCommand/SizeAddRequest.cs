using MediatR;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.SizesModule.Commands.SizeAddCommand
{
    public class SizeAddRequest : IRequest<Size>
    {
        public string Name { get; set; }
        public string SmallName { get; set; }
    }
}
